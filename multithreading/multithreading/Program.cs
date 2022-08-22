using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace multithreading
{ //base job class
    public class Job
    {
        public bool workComplete { get;protected set; }
        public object Result { get; protected set; }

        virtual public void Perform(Object stateInfo) { }

    }
    // override base job class with new job by passing it in on a different thread
    class Job1 : Job
    { 
        override public void Perform(Object stateInfo) 
        {
            workComplete = false;

            int hp = 0;

            for(int i = 0; i < 10; i++)
            {
                hp += 5;
            }

            Result = hp;
            workComplete = true;
        }
    }
    class Job2 : Job
    {
        override public void Perform(Object stateInfo)
        {
            workComplete = false;

            int y = 1;
            for (int i = 0; i < 10; i++)
            {
                y *= 5;
            }
            Result = y;
            workComplete = true;
        }
    }

    class Job3 : Job
    {
        override public void Perform(Object stateInfo)
        {
            workComplete = false;

            int x = 5;
            for (int i = 0; i < 5; i++)
            {
                x -= 1;
            }
            Result = x;
            workComplete = true;
        }
    }


    class JobManager
    { 
        ConcurrentDictionary<int, Job> jobHolder = new ConcurrentDictionary<int, Job>();
         //prevent 2 threads from adding same job so that it does not fail
        public bool TryAddJob(int id, Job job)
        {
            return jobHolder.TryAdd(id, job);
        }
         //find job that was added previously, try to find job with specific ID
        public bool TryExecuteJob(int id)
        {
            Job job;
            if(jobHolder.TryGetValue(id, out job))
            {
                return job.workComplete;
            }

            return false;
        }
        // combines functions, if successful then job is added and executed immediately
        public bool TryAddAndExecuteJob(int id, Job job)
        {
            bool added = jobHolder.TryAdd(id, job);
            if (added)
            {
                ThreadPool.QueueUserWorkItem(job.Perform);
                return true;
            }

            return false;

        }
        // gives ID of job, returns the job
        public  bool TryGetValue(int id, out Job job)
        {
            return jobHolder.TryGetValue(id, out job);
        }

        public bool IsJobDone(int id)
        {
            Job job;

            if(jobHolder.TryGetValue(id, out job))
            {
                return job.workComplete;
            }

            return false ;
        }



    }

    internal class Program
    {

        static void Main(string[] args)
        {
            JobManager jobManager = new JobManager();
            
            if (jobManager.TryAddAndExecuteJob(9, new Job1()))
            {
                Console.WriteLine("Job of 9 is executing");
            }

            if (jobManager.TryAddAndExecuteJob(8, new Job2()))
            {
                Console.WriteLine("another job of 8 is executing");
            }

            if (jobManager.TryAddAndExecuteJob(10, new Job3()))
            {
                Console.WriteLine("another job of 10 is executing");
            }

            //ensures job is completed, loops until job is done
            while (true)
            {
               

                if (jobManager.IsJobDone(8))
                {
                    Job job;
                    if (jobManager.TryGetValue(8, out job))
                    {
                        Console.WriteLine($"Job result is {(int)job.Result}");
                    }
                }

                if (jobManager.IsJobDone(9))
                {
                    Job job;
                    if(jobManager.TryGetValue(9, out job))
                    {
                    Console.WriteLine($"Job result is {(int)job.Result}");
                       // break;

                    }
                }

                if (jobManager.IsJobDone(10))
                {
                    Job job;
                    if (jobManager.TryGetValue(10, out job))
                    {
                        Console.WriteLine($"Job result is {(int)job.Result}");
                       // break;

                    }
                }


            }
            Console.ReadKey();

        }


    }
}