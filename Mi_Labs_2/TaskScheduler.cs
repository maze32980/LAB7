namespace Mi_Labs_2
{
    public sealed class TaskScheduler<TTask, TPriority> where TPriority : IComparable
    {
        private readonly SortedDictionary<TPriority, Queue<TTask>> tasks = new();
        private readonly List<TTask> taskPool = new();

        public delegate void TaskExecution(TTask task);
        public delegate void TaskInitialization(TTask task);
        public delegate void TaskReset(TTask task);

        public void AddTask(TTask task, TPriority priority)
        {
            if (!tasks.ContainsKey(priority))
            {
                tasks[priority] = new Queue<TTask>();
            }

            tasks[priority].Enqueue(task);
        }

        public TTask? GetTaskFromPool(TaskInitialization initialization)
        {
            if (!taskPool.Any())
            {
                return default;
            }

            TTask task = taskPool[0];
            taskPool.Remove(task);
            initialization(task);
            return task;
        }

        public void ReturnTaskToPool(TTask task, TaskReset reset)
        {
            reset(task);
            taskPool.Add(task);
        }

        public void ExecuteNext(TaskExecution executionDelegate)
        {
            if (!tasks.Any())
            {
                return;
            }

            TPriority highestPriority = tasks.Keys.Last();
            Queue<TTask> taskQueue = tasks[highestPriority];
            TTask? nextTask = taskQueue.Dequeue();

            if (!taskQueue.Any())
            {
                tasks.Remove(highestPriority);
            }

            executionDelegate(nextTask);
        }

        public void InputTaskFromConsole()
        {
            Console.WriteLine("Введіть завдання:");
            string taskInput = Console.ReadLine();

            Console.WriteLine("Введіть пріоритет завдання:");
            string priorityInput = Console.ReadLine();

            // Assuming TTask and TPriority have parse methods
            TTask task = (TTask)Convert.ChangeType(taskInput, typeof(TTask));
            TPriority priority = (TPriority)Convert.ChangeType(priorityInput, typeof(TPriority));

            AddTask(task, priority);
        }
    }
}