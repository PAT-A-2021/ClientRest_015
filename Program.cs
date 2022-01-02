using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Net;

namespace ClientRest_20190140015_Muhamad_Arief_P_Suradi
{
    internal class Program
    {
        string baseUrl = "http://localhost:9111/";
        
        void buatMahasiswa()
        {
            Mahasiswa mhs = new Mahasiswa();
            Console.Write("Masukkan Nama : ");
            mhs.nama = Console.ReadLine();
            Console.Write("Masukkan NIM : ");
            mhs.nim = Console.ReadLine();
            Console.Write("Masukkan Prodi : ");
            mhs.prodi = Console.ReadLine();
            Console.Write("Masukkan Angkatan : ");
            mhs.angkatan = Console.ReadLine();

            var data = JsonConvert.SerializeObject(mhs);
            var postData = new WebClient();
            postData.Headers.Add(HttpRequestHeader.ContentType,"application/json");
            string response = postData.UploadString(baseUrl + "Mahasiswa",data);
            Console.WriteLine(response);

        }
        static void Main(string[] args)
        {
            ClassData cl = new ClassData();
            cl.getData();
            Program app = new Program();
            app.buatMahasiswa();
            Console.ReadLine();
        }
    }

    [DataContract]
    public class Mahasiswa
    {
        private string _nama,_nim,_prodi,_angkatan;
        [DataMember]
        public string nama
        {
            get { return _nama; }
            set { _nama = value; }
        }
        [DataMember]
        public string nim
        {
            get { return _nim; }
            set { _nim = value; }
        }
        [DataMember]
        public string prodi
        {
            get { return _prodi; }
            set { _prodi = value; }
        }
        [DataMember]
        public string angkatan
        {
            get { return _angkatan; }
            set { _angkatan = value; }
        }
    }
}
