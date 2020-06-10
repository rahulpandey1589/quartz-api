using quartz_app.core;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace quartz_app.db
{
    public class QueueDBConnection
    {
        private static string connectionString =
            ConfigurationManager.AppSettings["SqlConnection"];


        public void AddMessageToQueue(string message)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    var command = new SqlCommand("dbo.AddMessageToQueue", sqlConnection) { CommandType = CommandType.StoredProcedure };

                    command.Parameters.Add(new SqlParameter("@sourceServiceName", "PaymentOrderService"));
                    command.Parameters.Add(new SqlParameter("@targetServiceName", "PaymentOrderService"));
                    command.Parameters.Add(new SqlParameter("@contractName", "ServiceBrokerContract"));
                    command.Parameters.Add(new SqlParameter("@messageName", "ServiceBrokerMessage"));
                    command.Parameters.Add(new SqlParameter("@message", message));

                    command.ExecuteNonQuery();

                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }


        public IMessage ReadItemFromQueue(string queueName)
        {
            IMessage message = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("dbo.ReadFromQueue", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.Add(new SqlParameter("@targetQueueName", queueName));

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader["MessageId"] != DBNull.Value)
                        {
                            message = new Message
                            {
                                MessageId =
                                        new Guid(Convert.ToString(reader["MessageId"])),
                                MessageText = Convert.ToString(reader["Message"])
                            };
                        }

                        break; // expecting only 1 record at a time.
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    connection.Close();
                }
                return message;
            }
        }

    }
}
