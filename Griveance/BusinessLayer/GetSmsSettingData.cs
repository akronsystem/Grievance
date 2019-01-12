using Griveance.Models;
using Griveance.ParamModel;
using Griveance.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Griveance.BusinessLayer
{
    public class GetSmsSettingData
    {
        GRContext objGR = new GRContext();
        public object GetSmsSettingsDataBL()
        {
            try
            {
                var Smsdata = objGR.tbl_smsconfiguration.Where(r=>r.DISPLAY==1).ToList();
               if(Smsdata==null)
                {
                    return new Error() { IsError = true, Message = "No Data Found." };
                }
                else
                {
                    return new Result() { IsSucess = true, ResultData = Smsdata };
                }
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }


        public object SaveSmsSetting(ParamSmsSetting PS)
        {
            try
            {
                tbl_smsconfiguration objTBL = new tbl_smsconfiguration();
                objTBL.GATEWAYUSERID = PS.GatewayUserid;
                objTBL.GATEWAYPASSWORD = PS.GatewayPassword;
                objTBL.SMSSENDAPI = PS.SmsSendApi;
                objTBL.CHECKBALANCEAPI = PS.CheckbalanceApi;
                objTBL.DISPLAY = 1;
                objTBL.created_date = DateTime.Now;
               
                objGR.tbl_smsconfiguration.Add(objTBL);
                objGR.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Sms Settings Saved Succesfully!!" };
            }
            catch(Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }

        public object GetSingleSmsSettingData(ParamSmsSetting objPS)
        {
            try
            {
                var SmsData = objGR.tbl_smsconfiguration.Where(r => r.SETTINGID == objPS.SettingId).First();
                if(SmsData==null)
                {
                    return new Error() { IsError = true, Message = "No records Found." };
                }
                else
                {
                    // return new Result() { IsSucess = true, ResultData = SmsData };
                    return SmsData;
                }
            }
            catch(Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }
        }

        public object UpdateSmsSetting(ParamSmsSetting objPS)
        {
            try
            {
                tbl_smsconfiguration objTBL = objGR.tbl_smsconfiguration.Where(r => r.SETTINGID == objPS.SettingId).First();
                objTBL.GATEWAYUSERID = objPS.GatewayUserid;
                objTBL.GATEWAYPASSWORD = objPS.GatewayPassword;
                objTBL.SMSSENDAPI = objPS.SmsSendApi;
                objTBL.CHECKBALANCEAPI = objTBL.CHECKBALANCEAPI;
                objTBL.modified_date = DateTime.Now;
                objGR.SaveChanges();
                return new Result() { IsSucess = true, ResultData = "Sms Settings Updated Successfully." };

            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }
    }
}