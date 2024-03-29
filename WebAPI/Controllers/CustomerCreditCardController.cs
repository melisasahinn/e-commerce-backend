﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCreditCardController : Controller
    {
        ICustomerCreditCardService _customerCreditCardService;
        public CustomerCreditCardController(ICustomerCreditCardService customerCreditCardService)
        {
            _customerCreditCardService = customerCreditCardService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result =  _customerCreditCardService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbycustomerid")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = _customerCreditCardService.GetByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getdetailsbycustomerid")]
        public IActionResult GetDetailsByCustomerId(int customerId)
        {
            var result =  _customerCreditCardService.GetDetailsByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CustomerCreditCard customerCreditCard)
        {
            var result =  _customerCreditCardService.Add(customerCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CustomerCreditCard customerCreditCard)
        {
            var result =  _customerCreditCardService.Delete(customerCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CustomerCreditCard customerCreditCard)
        {
            var result = _customerCreditCardService.Update(customerCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}