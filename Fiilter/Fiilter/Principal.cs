﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Fiilter
{
    class Principal
    {
        public List<FII> FIIs { get; private set; }

        public Principal()
        {
            FIIs = new List<FII>();
            scrape();
        }

        private void scrape()
        {
            string page = "https://www.fundsexplorer.com.br/ranking";

            var web = new HtmlWeb();
            var doc = web.Load(page);

            var LinhasResult = doc.DocumentNode.SelectNodes("//tr");
            if (LinhasResult != null)
            {
                foreach (var linha in LinhasResult)
                {
                    List<string> aux = new List<string>();
                    var dadosnumericos = linha.SelectNodes(".//td");

                    if (dadosnumericos != null)
                    {

                        foreach (var dado in dadosnumericos)
                        {
                            aux.Add(HttpUtility.HtmlDecode(dado.InnerText));

                        }
                        try
                        {
                            FIIs.Add(new FII(aux));
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
        }
    }
}
