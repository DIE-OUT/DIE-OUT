using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Afired.Helper {
    
    public class TaskQueue {
        
        private Queue<Func<Task>> _queuedFunctions;
        
        
        public TaskQueue() {
            _queuedFunctions = new Queue<Func<Task>>();
        }
        
        public async Task InvokeSynchronously() {
            while(_queuedFunctions.Count > 0) {
                await _queuedFunctions.Dequeue().Invoke();
            }
        }
        
        public async Task InvokeAsynchronously() {
            List<Task> tasks = new List<Task>();
            while(_queuedFunctions.Count > 0) {
                tasks.Add(_queuedFunctions.Dequeue().Invoke());
            }
            await Task.WhenAll(tasks);
        }

        public static TaskQueue operator +(TaskQueue taskQueue, Func<Task> function) {
            taskQueue.Add(function);
            return taskQueue;
        }

        public void Add(Func<Task> function) {
            _queuedFunctions.Enqueue(function);
        }

        public void Clear() {
            _queuedFunctions.Clear();
        }

    }
    
}
