using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace voxpopuliAPI.Models
{
    public class DataSourceChart
    {
        private List<CharData> _dataSource;
        private string _nombre;

        public DataSourceChart(string nombre, List<CharData> dataSource)
        {
            this._dataSource = dataSource;
            this._nombre = nombre;
        }
        public DataSourceChart()
        {
            this._dataSource = new List<CharData>();
            this._nombre = string.Empty;
        }

        public List<CharData> DataSource
        {
            get
            {
                return _dataSource;
            }

            set
            {
                _dataSource = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }
    }
}