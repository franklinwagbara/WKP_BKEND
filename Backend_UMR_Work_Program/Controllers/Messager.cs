using Microsoft.AspNetCore.Authentication.JwtBearer;
using Backend_UMR_Work_Program.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Security.Claims;
using static Backend_UMR_Work_Program.Models.GeneralModel;
using DocumentFormat.OpenXml.Bibliography;

namespace Backend_UMR_Work_Program.Controllers
{
    public static class Messager
    {
        public static string ShowMessage(string action)
        {
            var message = "";
            action = CapitalFirstFormating(action);
            if (action.Trim().ToLower() == "Insert".Trim().ToLower())
            {
                message = action + "ed";
            }
            else
            {
                message = action + "d";
            }
            return $"{message}  successfully.";
        }



        private static string CapitalFirstFormating(string action)
        {
            action = action.Trim().ToLower();
            if (string.IsNullOrEmpty(action))
                return string.Empty;
            // convert to char array of the string
            char[] letters = action.ToCharArray();
            // upper case the first char
           letters[0]=char.ToUpper(letters[0]);
            return new string(letters);
        }

    }
}
