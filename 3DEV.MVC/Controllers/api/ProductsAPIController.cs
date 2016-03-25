using _3DEV.DATA;
using _3DEV.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity.Infrastructure;

namespace _3DEV.MVC.Controllers.api
{    
    public class ProductsAPIController : ApiController
    {

        private ApplicationUnit _unit = new ApplicationUnit();

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Product> Get()
        {
            return _unit.Products.GetAll();
        }

        [HttpGet]        
        public Product Get(int id)
        {
            Product product = this._unit.Products.GetById(id);
            if (product == null)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return product;
        }
                
        
        public HttpResponseMessage Put(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != product.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Product existProduct = this._unit.Products.GetById(id);
            _unit.Products.Detach(existProduct);

            product.CreatedOn = existProduct.CreatedOn;

            this._unit.Products.Update(product);

            try
            {
                this._unit.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "{success:'true', verb:'PUT'}");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }


        [HttpPost]       
        public HttpResponseMessage Post(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    this._unit.Products.Add(product);
                    this._unit.SaveChanges();

                    HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.Created, product);

                    result.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = product.Id }));

                    return result;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "admin, manager, user")]
        public HttpResponseMessage Delete(int id)
        {
            Product product = this._unit.Products.GetById(id);


            if (product == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            this._unit.Products.Delete(product);

            try
            {
                this._unit.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, product);
            }
            catch (DbUpdateConcurrencyException ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.OK, ex);
            }
        }

        
    }
}
