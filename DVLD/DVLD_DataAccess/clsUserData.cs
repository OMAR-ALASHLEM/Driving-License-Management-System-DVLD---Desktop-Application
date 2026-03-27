using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsUserData
    {
        public static bool GetUserByID(int User_ID, ref int Person_ID, ref string Username, ref string Password, ref bool IsActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Users WHERE User_ID = @User_ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@User_ID", User_ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    User_ID = (int)reader["User_ID"];
                    Person_ID = (int)reader["Person_ID"];
                    Username = (string)reader["Username"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                }
                reader.Close();
            }
            catch (Exception)
            {


            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }

        public static bool GetUserInfoByPersonID(int PersonID, ref int UserID, ref string UserName,
        ref string Password, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Users WHERE Person_ID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;

                    UserID = (int)reader["User_ID"];
                    UserName = (string)reader["Username"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];


                }
                else
                {

                    isFound = false;
                }

                reader.Close();

            }
            catch 
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool GetUserByUsernameAndPassword(string Username, string Password, ref int User_ID, ref int Person_ID, ref bool IsActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Users WHERE Username = @Username and Password=@Password ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    User_ID = (int)reader["User_ID"];
                    Person_ID = (int)reader["Person_ID"];
                    Username = (string)reader["Username"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];
                }
                reader.Close();
            }
            catch
            { }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static bool IsUserExist(int User_ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Found=1 FROM Users WHERE User_ID = @User_ID ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@User_ID", User_ID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null) isFound = true;
            }
            catch { isFound = false; }
            finally { connection.Close(); }

            return isFound;

        }
        public static bool IsUserExist(string Username)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Found=1 FROM Users WHERE Username = @Username ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null) isFound = true;
            }
            catch { isFound = false; }
            finally { connection.Close(); }

            return isFound;

        }
        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM Users  ";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch
            { }
            finally { connection.Close(); }
            return dt;
        }
        public static int AddNewUser(int Person_ID, string Username, string Password, bool IsActive)
        {
            int _UserID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Users 
                         (Person_ID, Username, Password, IsActive)
                         VALUES 
                         (@Person_ID, @Username, @Password, @IsActive);
                         SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Person_ID", Person_ID);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    _UserID = insertedID;
                }
            }
            catch
            { }
            finally { connection.Close(); }
            return _UserID;

        }
        public static bool UpdateUser(int User_ID, int Person_ID, string Username, string Password, bool IsActive)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Users 
                         SET Person_ID = @Person_ID, 
                             Username = @Username, 
                             Password = @Password, 
                             IsActive = @IsActive, 
                         WHERE User_ID = @User_ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@User_ID", User_ID);
            command.Parameters.AddWithValue("@Person_ID", Person_ID);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch
            { return false; }
            finally { connection.Close(); }
            return (rowsAffected > 0);

        }
        public static bool DeleteUser(int User_ID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "DELETE Users WHERE User_ID = @User_ID ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@User_ID", User_ID);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch { return false; }
            finally { connection.Close(); }

            return (rowsAffected > 0);

        }
        public static bool IsUserExistForPersonID(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Users WHERE Person_ID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool DoesPersonHaveUser(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Users WHERE Person_ID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch 
            {
              
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool ChangePassword(int UserID, string NewPassword)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Users  
                            set Password = @Password
                            where User_ID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch 
            {
             
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
    }

}

