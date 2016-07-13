using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
namespace SpicejetService
{
    public class AircraftModel
    {
        public int AircraftModelId { get; set; }
        public int AircraftTypeID { get; set; }
        public string AircraftModelName { get;set;}
        public int TotalSeats { get; set; }
        public int CreatedBy { get; set; }
        public int LastModifiedBy { get; set; }
        public string AircraftType { get; set; }
        public int MAircraftTypeID { get; set; }
        public string MAircraftType { get; set; }


        public List<AircraftModel> AircraftTypeSelectList(AircraftModel objaircraftType)
        {
            var _BindAirCraftTypeList = new List<AircraftModel>();
            string[] strDataTableName = { "tbl_M_airCraftType" };
            DataSet ds = new DataSet();
            SqlParameter[] parameters = new SqlParameter[]
               {
                     new SqlParameter("@AircraftTypeID", objaircraftType.MAircraftTypeID),
               };
            ds = DBConnection.ExecuteSelectCommand("Proc_tbl_M_AircraftType_select ", CommandType.StoredProcedure, strDataTableName, parameters);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                _BindAirCraftTypeList.Add(new AircraftModel()
                {
                     MAircraftTypeID =Convert.ToInt32(dr["AircraftTypeID"]),
                     MAircraftType=Convert.ToString(dr["AircraftType"])
                });
                
            }
            return _BindAirCraftTypeList;
        }

        public List<AircraftModel> AirCraftModelSelectList(AircraftModel objaircraftModel)
        {
            var _BindAircraftModel = new List<AircraftModel>();
            string[] strDataTableName = { "tbl_M_AircraftModel" };
            DataSet ds = new DataSet();
            SqlParameter[] parameters = new SqlParameter[]
               {
                     new SqlParameter("@AircraftModelID", objaircraftModel.AircraftModelId)
               };
          
            ds = DBConnection.ExecuteSelectCommand("proc_tbl_M_AircraftModel_Select", CommandType.StoredProcedure, strDataTableName, parameters);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                _BindAircraftModel.Add(new AircraftModel()
                {
                      AircraftModelId=Convert.ToInt32(dr["AircraftModelID"]),
                      AircraftTypeID=Convert.ToInt32(dr["AircraftTypeID"]),
                      AircraftModelName=Convert.ToString(dr["AircraftModelName"]),
                      TotalSeats = Convert.ToInt32(dr["TotalSeats"]),
                      AircraftType=Convert.ToString(dr["AircraftType"])
                });
            }
            return _BindAircraftModel;
        }

        public List<AircraftModel> AirCraftList(AircraftModel objaircraftmodel)
        {
            var _BindAircraftMaster = new List<AircraftModel>();
            string[] strDataTableName = { "tbl_M_AircraftModel" };
            DataSet ds = new DataSet();
            SqlParameter[] parameters = new SqlParameter[]
                {
                     
                     new SqlParameter("@AircraftModelID", objaircraftmodel.AircraftModelId), 
                    
                
                };
            ds = DBConnection.ExecuteSelectCommand("Usp_Bind_Aircraft_Model", CommandType.StoredProcedure, strDataTableName, parameters);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                _BindAircraftMaster.Add(new AircraftModel()
                {
                    AircraftModelId = Convert.ToInt32(dr["AircraftModelID"]),
                   //AircraftTypeID = Convert.ToInt32(dr["AircraftTypeID"]),
                    AircraftModelName=Convert.ToString(dr["AircraftModelName"])
                });

            }
            return _BindAircraftMaster;
        }


       //=====================================Insert Update  Aircraft Model =====================================
        public int InsertMAircraftModel(AircraftModel objAir)
        {
            SqlCommand cmd = new SqlCommand();
            int result = 0;
            SqlParameter OutParameter = new SqlParameter();
            OutParameter.ParameterName = "@result";
            OutParameter.Value = "0";
            OutParameter.Direction = System.Data.ParameterDirection.Output;
            SqlParameter[] parameters = new SqlParameter[]
            {
                  new SqlParameter("@AircraftTypeID", objAir.AircraftTypeID),
                  new SqlParameter("@AircraftModelName", objAir.AircraftModelName),
                  new SqlParameter("@TotalSeats", objAir.TotalSeats),
                  new SqlParameter("@userId", objAir.CreatedBy),
                  OutParameter
            };
            result = DBConnection.ExecuteNonQuery("proc_tbl_M_AircraftModel_Insert", CommandType.StoredProcedure, parameters);
            object objRCodeVal = OutParameter.Value;
            int rcode = Convert.ToInt32(objRCodeVal);
            return rcode;
        }

        public int ModifyMAircraftModel(AircraftModel objair)
        {
            SqlCommand cmd = new SqlCommand();
            int result = 0;
            SqlParameter OutParameter = new SqlParameter();
            OutParameter.ParameterName = "@result";
            OutParameter.Value = "0";
            OutParameter.Direction = System.Data.ParameterDirection.Output;
            SqlParameter[] parameters = new SqlParameter[]
            {
                  new SqlParameter("@AircraftModelID", objair.AircraftModelId),
                  new SqlParameter("@AircraftTypeID", objair.AircraftTypeID),
                  new SqlParameter("@AircraftModelName", objair.AircraftModelName),
                  new SqlParameter("@TotalSeats", objair.TotalSeats),
                  new SqlParameter("@UesrId", objair.CreatedBy),
                  OutParameter
            };
            result = DBConnection.ExecuteNonQuery("proc_tbl_M_AircraftModel_Update", CommandType.StoredProcedure, parameters);
            object objRCodeVal = OutParameter.Value;
            int rcode = Convert.ToInt32(objRCodeVal);
            return rcode;
        }

        public int DeleteMAircraftModel(AircraftModel objair)
        {
            SqlCommand cmd = new SqlCommand();
            int result = 0;
            SqlParameter OutParameter = new SqlParameter();
            OutParameter.ParameterName = "@result";
            OutParameter.Value = "0";
            OutParameter.Direction = System.Data.ParameterDirection.Output;
            SqlParameter[] parameters = new SqlParameter[]
            {
                  new SqlParameter("@AircraftModelID", objair.AircraftModelId),
                  new SqlParameter("@UserId", objair.LastModifiedBy),
                    OutParameter
            };
            result = DBConnection.ExecuteNonQuery("proc_tbl_M_AircraftModel_Delete", CommandType.StoredProcedure, parameters);
          
            object objRCodeVal = OutParameter.Value;
            int rcode = Convert.ToInt32(objRCodeVal);
            return rcode;
        }


    }

    public class ResponseAircraftModel
    {
        public List<AircraftModel> responseObject { get; set; }
        public string responseCode { get; set; }

        public string responseMessage { get; set; }
    }
}