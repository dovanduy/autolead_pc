using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoLeadX
{
    class ThreadManager
    {
        private static ThreadManager Instance = null;
        private Dictionary<string, Thread> threadMap;
        private Dictionary<string, ThreadStart> delegateMap;

        private ThreadManager()
        {

        }

        public static ThreadManager getInstance()
        {
            if (Instance == null)
                Instance = new ThreadManager();
            return Instance;
        }

        public void init(Dictionary<string, ThreadStart> delegateMap)
        {
            this.delegateMap = delegateMap;
            this.threadMap = new Dictionary<string, Thread>();
        }

        public void tryStartOrResumeThread(string threadName)
        {
            if (delegateMap.ContainsKey(threadName))
            {
                if (threadMap.ContainsKey(threadName))
                {
                    Thread storedSthread = threadMap[threadName];
                    if ((storedSthread.ThreadState & ThreadState.Suspended) == ThreadState.Suspended)
                    {
                        try
                        {
                            storedSthread.Resume();
                            while ((storedSthread.ThreadState & ThreadState.Running) != ThreadState.Running)
                                Thread.Sleep(500);
                        }
                        catch (Exception) { }
                        Console.WriteLine("[ThreadManager] Resume thread: " + threadName);
                        return;
                    }
                    else
                    {
                        storedSthread.Abort();
                        this.threadMap.Remove(threadName);
                    }
                }

                Thread newThread = new Thread(this.delegateMap[threadName]);
                this.threadMap[threadName] = newThread;
                this.threadMap[threadName].Start();
            }
        }

        public void trySuspendThread(string threadName)
        {
            if (threadMap.ContainsKey(threadName))
            {
                Thread storedSthread = threadMap[threadName];
                if ((storedSthread.ThreadState & ThreadState.Running) == ThreadState.Running)
                {
                    try
                    {
                        storedSthread.Suspend();
                        while ((storedSthread.ThreadState & ThreadState.Suspended) != ThreadState.Suspended)
                            Thread.Sleep(500);
                    }
                    catch (Exception) { }                    
                    Console.WriteLine("[ThreadManager] suspend thread: " + threadName);
                    return;
                }
            }
        }

        public void tryStopThread(string threadName)
        {
            if (threadMap.ContainsKey(threadName))
            {
                Thread storedSthread = threadMap[threadName];
                if ((storedSthread.ThreadState & ThreadState.Running) == ThreadState.Running)
                {
                    try
                    {
                        storedSthread.Abort();
                        while ((storedSthread.ThreadState & ThreadState.Stopped) != ThreadState.Stopped)
                            Thread.Sleep(500);
                    }
                    catch (Exception) { }
                    this.threadMap.Remove(threadName);
                    Console.WriteLine("[ThreadManager] Abort thread: " + threadName);
                    return;
                }
            }
        }

        public void disableAllThead()
        {
            if (this.threadMap == null)
                return;

            foreach(string key in this.threadMap.Keys)
            {
                try
                {
                    this.threadMap[key].Abort();
                }
                catch(Exception ex)
                {

                }
            }
            this.threadMap.Clear();
        }

    }
}
