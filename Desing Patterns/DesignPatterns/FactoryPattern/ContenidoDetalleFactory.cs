using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace DesignPatterns.FactoryPattern
{
    /*Clase factory que crea un objeto donde se almacenara el llenado del archivo bancario
     * se crea un objeto base con las propiedades que se ocupan para el primer banco
    * dependiendo del banco creara un objeto diferente
    * cuando se agregue un nuevo banco se creara un nuevo producto de este
    */
    public abstract class ContenidoDetalleFactory
    {
        public abstract IDetalle GetDetail();
    }

    public interface IDetalle
    {
        void FillDetail(string header, string detail, string summary);
    }

    public class DetalleData : IDetalle
    {
        private string _header = "";
        private string _detail = "";
        private string _summary = "";

        public DetalleData(string header, string detail, string summary)
        {
            _header = header;
            _detail = detail;
            _summary = summary;
        }

        public void FillDetail(string header, string detail, string summary)
        {
            _detail = _detail + " new detail " + detail + Environment.NewLine;
            Console.WriteLine("Se ha creado el objeto con datos " + _header + " " + _detail + " " + _summary);
        }
    }

    public class SantanderDetalle : ContenidoDetalleFactory
    {

        private string _codigoBanco = "";
        public SantanderDetalle(string codigoBanco)
        {
            _codigoBanco = codigoBanco;
        }

        public override IDetalle GetDetail()
        {
            return new DetalleData(_codigoBanco,"","");
        }

    }

    public class BBVADetalle : ContenidoDetalleFactory
    {

        private string _codigoBanco = "";
        public BBVADetalle(string codigoBanco)
        {
            _codigoBanco = codigoBanco;
        }

        public override IDetalle GetDetail()
        {
            return new DetalleData(_codigoBanco, "", "");
        }

    }

    public class BanorteDetalle : ContenidoDetalleFactory
    {

        private string _codigoBanco = "";
        public BanorteDetalle(string codigoBanco)
        {
            _codigoBanco = codigoBanco;
        }

        public override IDetalle GetDetail()
        {
            return new DetalleData(_codigoBanco, "", "");
        }

    }

}
