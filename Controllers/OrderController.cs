using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Order.Models;
using System.Data;
using Order.Services;

namespace Order.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        OrderService orderService = new OrderService();
        //OrderService orderservice= new OrderService();



        //[HttpGet("GetAll")]
        //public async Task<ActionResult<DataTable>> Get()
        //{
        //    return Ok(await _orderService.GetAllOrders());
        //}
        [HttpGet("GetAll")]
        public async Task<JObject> Get()
        {
            JObject response_json = new JObject();
            try
            {

                var response = orderService.GetAllOrders();

                
               if (response.Rows.Count > 0) {
                    JArray children = new JArray();
                    int i = 0;
                    foreach (DataRow row in response.Rows)
                    {
                        JObject child = new JObject();
                        foreach (DataColumn col in response.Columns)
                        {
                            child.Add(col.ColumnName, response.Rows[i][col].ToString());
                        }
                        children.Add(child);
                        i++;
                    }
                    //response_json.Add("STATUS", response.Rows[i]["Status"].ToString());
                    //response_json.Add("RESPONSEMESSAGE", "Success!");
                    response_json.Add("STATUS", "Success");
                    response_json.Add("DATA", children);
                }
                else
                {
                    response_json.Add("STATUS", "Failed");
                    response_json.Add("RESPONSEMESSAGE", "Failed to get agents!");
                }
            }
            catch (Exception ex)
            {
                response_json.Add("STATUS", "Failed");
                response_json.Add("RESPONSEMESSAGE", ex.Message);
            }

            return response_json;
        }




        //[HttpGet("{id}")]
        //public async Task<ActionResult<MyOrder>> GetSingleOrder(int id)
        //{
        //    return Ok(await _orderService.GetOrderById(id));
        //}

        [HttpGet("{id}")]
        public async Task<JObject> Get(int Id)
        {

            JObject response_json = new JObject();
            try
            {
                var response = orderService.GetOrderById(Id);
                if (response.Rows.Count > 0)
                {
                    JObject child = new JObject();
                    foreach (DataColumn col in response.Columns)
                    {
                        child.Add(col.ColumnName, response.Rows[0][col].ToString());
                    }

                    JToken b = JToken.FromObject(response.Rows[0]);
                    //response_json.Add("RESPONSECODE", "00");
                    //response_json.Add("Status", response.Rows[0]["Status"].ToString());
                    response_json.Add("DATA", child);
                    response_json.Add(response.Rows[0].ToString());
                }
                else
                {
                    response_json.Add("Status", "Failed to add!");
                    //response_json.Add("RESPONSEMESSAGE", "Failed to get agent!");
                }
            }
            catch (Exception ex)
            {
                response_json.Add("Status", "Failed to add!");
                response_json.Add("RESPONSEMESSAGE", ex.Message);
            }

            return response_json;
        }




        //[HttpPost]
        //public async Task<ActionResult<List<MyOrder>>> AddOrder(MyOrder newOrder)
        //{
        //    return await _orderService.AddOrder(newOrder);
        //}
        [HttpPost]
        public async Task<JObject> Post(MyOrder order)
        {

            JObject response_json = new JObject();

            try
            {
                var response = orderService.AddOrder(order.Item, order.BuyerName, order.SellerName, order.Description
                , order.Amount, order.Date);

                if (response.Rows.Count > 0)
                {
                    response_json.Add("Status", response.Rows[0]["Status"].ToString());
                    //response_json.Add("RESPONSEMESSAGE", response.Rows[0]["RESPONSEMESSAGE"].ToString());
                }
                else
                {
                    response_json.Add("Status", response.Rows[0]["Status"].ToString());
                    //response_json.Add("RESPONSEMESSAGE", "Failed to add!");
                }
            }
            catch (Exception ex)
            {
                response_json.Add("Status", "Failed to add!");
                //response_json.Add("RESPONSEMESSAGE", ex.Message);
            }

            return response_json;
        }




        //[HttpPut]
        //public async Task<ActionResult<List<MyOrder>>> UpdateOrder(MyOrder updatedOrder)
        //{
        //    return Ok(await _orderService.UpdateOrder(updatedOrder));
        //}
        [HttpPut("{id}")]
        public async Task<JObject> Put(MyOrder order)
        {

            JObject response_json = new JObject();

            try
            {
                var response = orderService.UpdateOrder(order.Id, order.Item, order.BuyerName, order.SellerName, order.Description
                , order.Amount, order.Date);

                if (response.Rows.Count > 0)
                {
                    response_json.Add("Status", response.Rows[0]["Status"].ToString());
                    //response_json.Add("RESPONSEMESSAGE", response.Rows[0]["RESPONSEMESSAGE"].ToString());
                }
                else
                {
                    response_json.Add("Status", "Failed to add!");
                    //response_json.Add("RESPONSEMESSAGE", "Failed to add!");
                }
            }
            catch (Exception ex)
            {
                response_json.Add("Status", "Failed to add!");
                response_json.Add("RESPONSEMESSAGE", ex.Message);
            }

            return response_json;
        }





        //[HttpDelete("{id}")]
        //public async Task<ActionResult<MyOrder>> DeleteOrder(int id)
        //{
        //    return Ok(await _orderService.DeleteOrder(id));
        //}

        [HttpDelete("{id}")]
    public async Task<JObject> Delete(int Id)
        {

            JObject response_json = new JObject();

            try
            {
                var response = orderService.DeleteOrder(Id);

                if (response.Rows .Count > 0)
                {
                    response_json.Add("Status", response.Rows[0]["Status"].ToString());
                    
                }
                else
                {
                    response_json.Add("Status", "Failed to add!");

                }
            }
            catch (Exception ex)
            {
                response_json.Add("Status", "Failed to add!");
                response_json.Add("RESPONSEMESSAGE", ex.Message);
            }

            return response_json;
        }
    }
}
