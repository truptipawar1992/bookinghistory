using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingHistoryModuleWebAPI.Models;
using BookingHistoryModuleWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BookingHistoryModuleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private BookingHistoryService BookingHistoryservice;

        public HomeController(BookingHistoryService BookingHistory_service)
        {
            this.BookingHistoryservice = BookingHistory_service;
        }
         
    }
}