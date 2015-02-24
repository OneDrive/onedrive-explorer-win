using System;
using System.Threading.Tasks;

namespace OneDrive
{
    public static class ItemCollectionExtensionMethods
    {
        /// <summary>
        /// Returns true if there are more pages of items avaialble on the server
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static bool MoreItemsAvailable<T>(this ODCollectionResponse<T> collection)
        {
            return !string.IsNullOrEmpty(collection.NextLink);
        }

        /// <summary>
        /// Gets the next page of items as an ODItemCollection
        /// </summary>
        /// <param name="itemCollection"></param>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static async Task<ODItemCollection> GetNextPage(this ODItemCollection itemCollection, ODConnection connection)
        {
            if (null == connection) 
                throw new ArgumentNullException("connection");
            if (itemCollection.MoreItemsAvailable())
            {
                return await connection.DataModelForRequest<ODItemCollection>(new Uri(itemCollection.NextLink), ApiConstants.HttpGet);
            }
            else
            {
                return new ODItemCollection();
            }
        }

        public async static Task<ODViewChangesResult> GetNextResponseCollection(ODViewChangesResult previousCollection, ODConnection connection)
        {
            if (null == connection)
                throw new ArgumentNullException("connection");
            if (null == previousCollection)
                throw new ArgumentNullException("previousCollection");

            if (previousCollection.MoreItemsAvailable())
            {
                return await connection.DataModelForRequest<ODViewChangesResult>(new Uri(previousCollection.NextLink), ApiConstants.HttpGet);
            }
            else
            {
                return null;
            }
        }

        public async static Task<ODItemCollection> GetNextResponseCollection(ODItemCollection previousCollection, ODConnection connection)
        {
            if (null == connection)
                throw new ArgumentNullException("connection");
            if (null == previousCollection)
                throw new ArgumentNullException("previousCollection");

            if (previousCollection.MoreItemsAvailable())
            {
                return await connection.DataModelForRequest<ODItemCollection>(new Uri(previousCollection.NextLink), ApiConstants.HttpGet);
            }
            else
            {
                return null;
            }
        }
    }
}
