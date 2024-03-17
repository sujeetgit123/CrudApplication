using CrudApplication.CommonLayer.Model;
using CrudApplication.CommonUtility;
using MySqlConnector;

namespace CrudApplication.RepositoryLayer
{
    public class CrudApplicationRL : ICrudApplicationRL
    {
        public readonly IConfiguration _configuration;
        public readonly MySqlConnection _mySqlConnection;
        public CrudApplicationRL(IConfiguration configuration) 
        { 
            _configuration = configuration;
            _mySqlConnection = new MySqlConnection(_configuration["ConnectionStrings:mySQlDBString"]);
        }

        public async Task<AddInformationResponse> AddInformation(AddInformationRequest request)
        {
            AddInformationResponse response = new AddInformationResponse();
            try
            {
                if(_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                   await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.AddInformation, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue("@EmailId", request.EmailId);
                    sqlCommand.Parameters.AddWithValue("@MobileNumber", request.MobileNumber);
                    sqlCommand.Parameters.AddWithValue("@Salary", request.Salary);
                    sqlCommand.Parameters.AddWithValue("@Gender", request.Gender);
                    
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if(status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Query not executed";

                        return response;
                    }
                    else
                    {
                        response.IsSuccess = true;
                        response.Message = "Record created successfully.";
                    }
                }
            } catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }

            return response;
        }

        public async Task<LoginInformationResponse> GetUserInformation(LoginInformationRequest request)
        {
            LoginInformationResponse response = new LoginInformationResponse();
            response.IsSuccess = false;
            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }
                else
                {
                    response.Message = "Unable to open mysql connection";
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.GetUserInformation, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@EmailId", request.EmailId);

                    using (MySqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            response.IsSuccess = true;
                            response.Message = "Process successfully.";
                            while (await dataReader.ReadAsync())
                            {
                                ReadAllInformation getData = new ReadAllInformation();
                                getData.id = dataReader["id"] != DBNull.Value ? (int)Convert.ToInt64(dataReader["id"]) : 0;
                                getData.UserName = dataReader["UserName"] != DBNull.Value ? Convert.ToString(dataReader["UserName"]) : "";
                                getData.EmailId = dataReader["EmailId"] != DBNull.Value ? Convert.ToString(dataReader["EmailId"]) : "";
                                getData.MobileNumber = dataReader["MobileNumber"] != DBNull.Value ? Convert.ToString(dataReader["MobileNumber"]) : "";
                                getData.Gender = dataReader["Gender"] != DBNull.Value ? Convert.ToString(dataReader["Gender"]) : "";
                                getData.Salary = dataReader["Salary"] != DBNull.Value ? (int)Convert.ToInt64(dataReader["Salary"]) : 0;
                                getData.isActive = dataReader["isActive"] != DBNull.Value ? Convert.ToBoolean(dataReader["isActive"]) : false;

                                response.User = getData;
                            }
                        }
                        else
                        {
                            response.IsSuccess = false;
                            response.Message = "Record not found";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }

            return response;
        }

        public async Task<UpdateAllInformationByIdResponse> UpdateAllInformationById(UpdateAllInformationByIdRequest request)
        {
            UpdateAllInformationByIdResponse response = new UpdateAllInformationByIdResponse();
            try
            {
                if(_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                   await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.UpdateAllInformationById, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@UserId", request.UserId);
                    sqlCommand.Parameters.AddWithValue("@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue("@EmailId", request.EmailId);
                    sqlCommand.Parameters.AddWithValue("@MobileNumber", request.MobileNumber);
                    sqlCommand.Parameters.AddWithValue("@Salary", request.Salary);
                    sqlCommand.Parameters.AddWithValue("@Gender", request.Gender);
                    
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if(status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Query not executed";

                        return response;
                    }
                    else
                    {
                        response.IsSuccess = true;
                        response.Message = "Record updated successfully.";
                    }
                }
            } catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }

            return response;
        }

        public async Task<DeleteInformationByIdResponse> DeleteInformationById(DeleteInformationByIdRequest request)
        {
            DeleteInformationByIdResponse response = new DeleteInformationByIdResponse();
            try
            {
                if(_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                   await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.DeleteInformationById, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@UserId", request.UserId);                    
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if(status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Query not executed";

                        return response;
                    }
                    else
                    {
                        response.IsSuccess = true;
                        response.Message = "Record deleted successfully.";
                    }
                }
            } catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }

            return response;
        }

        public async Task<ReadAllInformationResponse> ReadAllInformation()
        {
            ReadAllInformationResponse response = new ReadAllInformationResponse();
            try
            {
                if (_mySqlConnection.State != System.Data.ConnectionState.Open)
                {
                    await _mySqlConnection.OpenAsync();
                }

                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQueries.ReadAllInformation, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    
                    using(MySqlDataReader dataReader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if (dataReader.HasRows)
                        {
                            response.IsSuccess = true;
                            response.Message = "Process successfully.";
                            response.readAllInformation = new List<ReadAllInformation>();
                            while (await dataReader.ReadAsync())
                            {
                                ReadAllInformation getData = new ReadAllInformation();
                                getData.id = dataReader["id"] != DBNull.Value ? (int)Convert.ToInt64(dataReader["id"]) : 0;
                                getData.UserName = dataReader["UserName"] != DBNull.Value ? Convert.ToString(dataReader["UserName"]) : ""; 
                                getData.EmailId = dataReader["EmailId"] != DBNull.Value ? Convert.ToString(dataReader["EmailId"]) : ""; 
                                getData.MobileNumber = dataReader["MobileNumber"] != DBNull.Value ? Convert.ToString(dataReader["MobileNumber"]) : ""; 
                                getData.Gender = dataReader["Gender"] != DBNull.Value ? Convert.ToString(dataReader["Gender"]) : ""; 
                                getData.Salary = dataReader["Salary"] != DBNull.Value ? (int)Convert.ToInt64(dataReader["Salary"]) : 0;
                                getData.isActive = dataReader["isActive"] != DBNull.Value ? Convert.ToBoolean(dataReader["isActive"]) : false;

                                response.readAllInformation.Add(getData);
                            }
                        }
                        else
                        {
                            response.IsSuccess = false;
                            response.Message = "Record not found";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }

            return response;
        }
    }
}
