using System;
using System.Threading.Tasks;

namespace OneDrive
{
    public static class AsyncJobsExtensionMethods
    {
        public static async Task Refresh(this ODAsyncTask pendingTask, ODConnection connection)
        {
            await connection.RefreshAsyncTaskStatus(pendingTask);
        }
    }
}
