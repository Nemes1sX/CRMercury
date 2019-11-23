using System;

namespace CRMercury.App.Dto
{

    public class CompanyDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string ceoname { get; set; }
        public string website { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public bool status { get; set; }
    }
}