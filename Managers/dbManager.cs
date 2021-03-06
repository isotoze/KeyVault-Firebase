﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using KeyVault.Objects;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KeyVault.Managers
{
    public class DbManager
    {
        List<ProductKey> products = null;
        Library library = new Library();

        public FireSharp.FirebaseClient client { get; set; }

        IFirebaseConfig config = new FirebaseConfig
        { 
            AuthSecret = "NRtEPJESMFVUHEDot1Ld14LV0m3OA476EmhGRwE6",
            BasePath = "https://keyvault-d482f.firebaseio.com/"
        };

        public Boolean connect()
        {
            try
            {
                this.client = new FireSharp.FirebaseClient(config);

                if(client != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                library.errorHandler(ex);
                return false;
            }
        }

        public async void insert(ProductKey key)
        {
            try
            {

                FirebaseResponse response = await client.GetAsync("Counter/node");
                Counter currentCount = response.ResultAs<Counter>();

                //Assign unique ID
                key.ID = currentCount.count + 1;

                response = await client.SetAsync("Keys/"+key.ID, key);

                //Create an object to update the counter.
                var countObj = new Counter
                { 
                    count = key.ID
                };

                //Update the counter.
                response = await client.SetAsync("Counter/node",countObj);


            }
            catch (Exception ex)
            {
                library.errorHandler(ex);
            }
        }

        public async void remove(int id)
        {
            var count = 0;
            try
            {
                if(id != 0)
                {
                    FirebaseResponse response = await client.GetAsync("Counter/node");
                    Counter currentCount = response.ResultAs<Counter>();
                    count = currentCount.count;

                    count -= 1;
                    response = await client.SetAsync("Counter/node/count", count);

                    response = await client.DeleteAsync("Keys/" + id);
                }
            }
            catch(Exception ex)
            {
                library.errorHandler(ex);
            }
        }

        public async Task<List<ProductKey>> getAll()
        {
            int count = 0;
            List<ProductKey> keys = null;
            var i = 0;
            try
            {
                keys = new List<ProductKey>();
                FirebaseResponse countResponse = await client.GetAsync("Counter/node");
                Counter currentCount = countResponse.ResultAs<Counter>();
                count = currentCount.count;

                while(true)
                {
                    if(i == count)
                    {
                        break;
                    }

                    i++;
                    FirebaseResponse keyResponse = await client.GetAsync("Keys/" + i);
                    ProductKey key = keyResponse.ResultAs<ProductKey>();
                    keys.Add(key);
                }
            }
            catch(Exception ex)
            {
                library.errorHandler(ex);
            }
            return keys;
        }
    }
}
