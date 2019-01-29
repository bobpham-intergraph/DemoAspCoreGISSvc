using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongodbConnect.Models.GIS
{
   
    public class MultiPoint
    {
        public MultiPoint()
        {
            coordinates = new List<double[]>();
        }
       
        public List<double[]> coordinates { get; set; }
        
       
        public string type { get; set; }
    }


    public class MultiPointType: List<double[]>
    {
        
    }

    public class MultiPolygon
    {
        public MultiPolygon()
        {
            coordinates = new List<MultiPointType[]>();
        }

        public List<MultiPointType[]> coordinates { get; set; }


        public string type { get; set; }
    }
}
