using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace voxpopuliAPI.Models
{
    public class CharData
    {
        private string _nombre;
        private int _porcentaje;
        private bool _explode;

        public CharData(string nombre, int porcentaje, bool explode)
        {
            this._nombre = nombre;
            this._porcentaje = porcentaje;
            this.Explode = explode;
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

        public int Porcentaje
        {
            get
            {
                return _porcentaje;
            }

            set
            {
                _porcentaje = value;
            }
        }

        public bool Explode
        {
            get
            {
                return _explode;
            }

            set
            {
                _explode = value;
            }
        }
    }
}