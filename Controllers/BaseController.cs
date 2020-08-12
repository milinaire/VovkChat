using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vovk_Chat.Models;

namespace Vovk_Chat.Controllers
{
    //Абстрактний клас для спрощення контролерів
    public abstract class BaseController : Controller
    {
        protected readonly IChatDB _chatdb;
        protected readonly IServiceProvider _serviceProvider;

        //Ін'єкція датабази сінглтона та контейнера IServiceProvider для резолвів
        public BaseController(IChatDB ChatDB, IServiceProvider serviceProvider)
        {
            this._chatdb = ChatDB;
            this._serviceProvider = serviceProvider;
        }
    }
}