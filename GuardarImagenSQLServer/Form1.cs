using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace GuardarImagenSQLServer
{
    public partial class Form1 : Form
    {
        public static string ConnectioString = "server=localhost;database=Test;user=sa;password=123456";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = @"..\..\File\Image\este.png";

            //var imageBase64sString = ConvertBase64String(path);
            var imageArrayByte = ConvertArrayByte(path);

            //var resonseString = this.AddImagenString(imageBase64sString);
            var resonseArrayByte = this.AddImagenArrayByte(imageArrayByte);

            this.SaveImgFileArrayByte(resonseArrayByte);
            //this.SaveImgFile(resonseString);
        }

        public string AddImagenString(string pImagenString)
        {
            using (var connection = new SqlConnection(ConnectioString))
            {
                connection.Open();

                const string procedure = @"INSERT INTO IMAGEN_USUARIO (ImagenString) VALUES (@pImagen)";

                var parameters = new DynamicParameters();
                parameters.Add("@pImagen", pImagenString, DbType.String);


                var response = connection.Execute(procedure, parameters, commandType: CommandType.Text);
                return pImagenString;
            }
        }

        public byte[] AddImagenArrayByte(byte[] pImagenArrayByte)
        {
            using (var connection = new SqlConnection(ConnectioString))
            {
                connection.Open();

                const string procedure = @"INSERT INTO IMAGEN_USUARIO (Imagen) VALUES (@pImagen)";

                var parameters = new DynamicParameters();
                parameters.Add("@pImagen", pImagenArrayByte, DbType.Binary);


                var response = connection.Execute(procedure, parameters, commandType: CommandType.Text);
                return pImagenArrayByte;
            }
        }

        public string ConvertBase64String(string pImagenString)
        {
            string base64string = "";

            if (pImagenString.Trim().Length > 0)
            {
                var imageByte = File.ReadAllBytes(pImagenString);
                base64string = Convert.ToBase64String(imageByte);
            }
            return base64string;
        }

        public byte[] ConvertArrayByte(string pImagenString)
        {
            byte[] arrayByte = null;

            if (pImagenString.Trim().Length > 0)
            {
                arrayByte = File.ReadAllBytes(pImagenString);
            }
            return arrayByte;
        }

        public  void SaveImgFile(string pImagenString)
        {
            byte[] arrayImagen = Convert.FromBase64String(pImagenString);

            string folderPath = @"..\..\Upload\";
            string fileNamelocal = "Imagen.png";
            string imagePath = folderPath + fileNamelocal;

            using (MemoryStream ms = new MemoryStream(arrayImagen))
            {
                var img = Image.FromStream(ms);
                img.Save(imagePath, ImageFormat.Png);
            }
        }

        public void SaveImgFileArrayByte(byte[] pImagenArrayByte)
        {
            byte[] arrayImagen = pImagenArrayByte;

            string folderPath = @"..\..\Upload\";
            string fileNamelocal = "Imagen.png";
            string imagePath = folderPath + fileNamelocal;

            using (MemoryStream ms = new MemoryStream(arrayImagen))
            {
                var img = Image.FromStream(ms);
                img.Save(imagePath, ImageFormat.Png);
            }
        }
    }
}
