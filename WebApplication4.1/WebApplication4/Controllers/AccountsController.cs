using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Salesforce.Force;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class AccountsController : Controller
    {
        // GET: /Accounts/
        public ActionResult Index(string searchString)
        {
            var accessToken = Session["AccessToken"].ToString();
            var apiVersion = Session["ApiVersion"].ToString();
            var instanceUrl = Session["InstanceUrl"].ToString();

            var client = new ForceClient(instanceUrl, accessToken, apiVersion);
            var allModels = new Tuple<List<AccountViewModel>,
    List<AccountViewModel1>>
    (client.QueryAsync<AccountViewModel>("SELECT id, name, BillingStreet, BillingCity, BillingState, BillingPostalCode FROM Account WHERE name LIKE '%" + searchString + "%'").Result.records, client.QueryAsync<AccountViewModel1>("SELECT id, name, BillingStreet, BillingCity, BillingState, BillingPostalCode FROM Account").Result.records) { };
            //var allAccounts = await client.QueryAsync<AccountViewModel1>("SELECT id, name, BillingStreet, BillingCity, BillingState, BillingPostalCode FROM Account");
            //var accounts = await client.QueryAsync<AccountViewModel>("SELECT id, name, BillingStreet, BillingCity, BillingState, BillingPostalCode FROM Account WHERE name LIKE '%" + searchString + "%'");

            return View(allModels);
        }
        public async Task<string> Index2(string searchString)
        {
            //var accessToken = Session["AccessToken"].ToString();
            //var apiVersion = Session["ApiVersion"].ToString();
            //var instanceUrl = Session["InstanceUrl"].ToString();

            //var client = new ForceClient(instanceUrl, accessToken, apiVersion);
            //Contact c = new Contact() { Name = GetLat("milwaukee"), BillingCity = "Tate" };
            //var accounts = await client.QueryAsync<AccountViewModel>("SELECT id, name, BillingStreet, BillingCity, BillingState, BillingPostalCode FROM Account");
            //var recordId = await client.UpdateAsync("Account", accounts.records[0].Id, c);

            return searchString;
        }
    }
}