using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FileLoader
{
    public class DbFileLoader : IFileLoader
    {
        private readonly FileInfo _file;
        /// <summary>
        /// file checksum using sha-1
        /// </summary>
        private string _sha;
        /// <summary>
        /// id of file in database
        /// </summary>
        public int Id { get; private set; }

        public DbFileLoader(string fileName)
        {   
            if( fileName == null || string.IsNullOrEmpty( fileName ))
                throw new ArgumentException( "File name cannot be null or empty" );
            _file = new FileInfo(fileName);
            if( ! _file.Exists )
                throw new FileNotFoundException( string.Format( "{0} not found", fileName ) );
            _sha = ComputeSha();
        }

        private string ComputeSha()
        {
            //Create new instance of SHA1 and convert the input data to array of bytes
            var calculator = SHA1 . Create();
            var buffer = calculator . ComputeHash( _file . OpenRead() );
            calculator . Clear();

            //loop for each byte, convert it to hexadecimal string and add it to StringBuilder
            StringBuilder stringBuilder = new StringBuilder();
            for( int i = 0; i < buffer . Length; i++ )
            {
                stringBuilder . Append( buffer[ i ] . ToString( "x2" ) );
            }

            // return hexadecimal string
            return stringBuilder . ToString();
        }
        /// <summary>
        /// checks whether file is in db 
        /// </summary>
        /// <returns></returns>
        public bool FileExistsInStorage()
        {
            //TODO: check if file is in db
            return false;
        }
        /// <summary>
        /// Upload file into db and sets Id property to be id of file containing record in db
        /// </summary>
        public void LoadFileInStorage()
        {
            // TODO: upload file to db
            // TODO: fill Id property once file is uploaded
            Console.WriteLine( "file stored in db" );
        }
    }
}