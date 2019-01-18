using Griveance.BusinessLayer;
using Griveance.ParamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Griveance.Models;


namespace Griveance.Controllers
{
    public class CommonController : ApiController
    {
        public object SetLiveUser([FromBody]StudentParameters objhome)
        {
            try
            {
                SetIsLiveForUser obj = new SetIsLiveForUser();
                var homemworkresult = obj.UserLive(objhome);
                return homemworkresult;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };

            }

        }
        [HttpPost]
        public object GetMyGrievance([FromBody]ParamGetMyGrievance objmy)
        {
            try
            {
                GetMyGrievanceBL obj = new GetMyGrievanceBL();
                var mygrievance = obj.GetMyGrievance(objmy);
                return mygrievance;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }

        public object SubmitGrievance([FromBody]ParamSaveGriveance objparam)
        {
            try
            {
                PostGriveance obj = new PostGriveance();
                var result = obj.SaveGrievance(objparam);
                return result;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }

        [HttpPost]
        public object GetEmailInformation([FromBody]ParamEmailSettings objemail)
        {
            try
            {
                GetEmailSettings obj = new GetEmailSettings();
                var status = objemail.DisplayStatus;
                var EmailList = obj.GetEmailSettList(status);
                return EmailList;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
        [HttpPost]
        public object SaveEmailSettings([FromBody]ParamEmailSettings objemail)
        {
            try
            {
                SaveEmailSetting obj = new SaveEmailSetting();
                var EmailList = obj.SaveEmail(objemail);
                return EmailList;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }


        }
        [HttpPost]
        public object GetSingleEmailInfo([FromBody]ParamEmailSettings objid)
        {
            try
            {
                GetEmailSettings obj = new GetEmailSettings();
                var EmailList = obj.GetEmailData(objid);
                return EmailList;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }
        [HttpPost]
        public object DeleteEmailInformation([FromBody]ParamEmailSettings objid)
        {
            try
            {
                SaveEmailSetting obj = new SaveEmailSetting();
                var EmailList = obj.DeleteEmailData(objid);
                return EmailList;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }


        [HttpPost]
        public object UpdateEmailSettings([FromBody]ParamEmailSettings objid)
        {
            try
            {
                SaveEmailSetting obj = new SaveEmailSetting();
                var EmailList = obj.UpdateEmail(objid);
                return EmailList;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }
        }


        [HttpPost]
        public object SmsSettingList([FromBody]ParamSmsSetting obj)
        {
            try
            {

                GetSmsSettingData objSMS = new GetSmsSettingData();
                var status = obj.DisplayStatus;
                var SmsData = objSMS.GetSmsSettingsDataBL(status);
                return SmsData;
            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }

        [HttpPost]
        public object SaveSmsSettings([FromBody]ParamSmsSetting objSMS)
        {
            try
            {
                GetSmsSettingData obj = new GetSmsSettingData();
                var SmsSetting = obj.SaveSmsSetting(objSMS);
                return SmsSetting;
            }
            catch (Exception ex)
            {
                return new Error() { IsError = true, Message = ex.Message };
            }


        }
        [HttpPost]
        public object GetSingleSmsSetting([FromBody] ParamSmsSetting objPS)
        {
            try
            {
                GetSmsSettingData objSMS = new GetSmsSettingData();
                var SingleData = objSMS.GetSingleSmsSettingData(objPS);
                return SingleData;

            }
            catch(Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }

        [HttpPost]
        public object UpdateSmsSettings([FromBody] ParamSmsSetting objPS)
        {
            try
            {
                GetSmsSettingData objSMS = new GetSmsSettingData();
                var result = objSMS.UpdateSmsSetting(objPS);
                return result;


            }
            catch(Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }
        }
        [HttpPost]
         public object DeleteSmsInformation([FromBody] ParamSmsSetting objsms)
        {
            try
            {
                GetSmsSettingData objSMS = new GetSmsSettingData();
                var result = objSMS.DeleteSmsSetting(objsms);
                return result;


            }
            catch (Exception e)
            {
                return new Error() { IsError = true, Message = e.Message };
            }

        }

    }
}
