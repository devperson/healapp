using System;
using System.IO;
using System.Reflection;

namespace HServer.Utils
{
    /// <summary>
    /// Helper class to work with assembly resources
    /// </summary>
    public class AssemblyResourceReader
    {
        private Assembly _assembly;

        private string GetResourceName(string pathFromAssembly)
        {
            return string.Format("{0}.{1}", _assembly.GetName().Name, pathFromAssembly);
        }

        public AssemblyResourceReader(Assembly assembly)
        {
            _assembly = assembly;
        }

        /// <summary>
        /// Reads resource as string
        /// </summary>
        /// <param name="resourceName">Name of resource to read from assembly root folder, as Resources.AddToFullTrust.vbs</param>
        /// <returns>String representation of resource file</returns>
        public string ReadResourceAsString(string resourceName)
        {
            using (var file = _assembly.GetManifestResourceStream(GetResourceName(resourceName)))
            {
                if (file == null)
                    throw new Exception(string.Format("Resource '{0}' was not found in the assembly '{1}'.", resourceName, _assembly.FullName));

                using (var reader = new StreamReader(file))
                    return reader.ReadToEnd();
            }
        }
        /// <summary>
        /// Reads resource as byte array
        /// </summary>
        /// <param name="resourceName">Name of resource to read from assembly root folder, as Resources.AddToFullTrust.vbs</param>
        /// <returns>Binary representation of resource file</returns>
        public byte[] ReadResourceBytes(string resourceName)
        {
            using (var file = _assembly.GetManifestResourceStream(GetResourceName(resourceName)))
            {
                if (file == null)
                    throw new Exception(string.Format("Resource '{0}' was not found in the assembly '{1}'.", resourceName, _assembly.FullName));

                using (var reader = new BinaryReader(file))
                {
                    using (var ms = new MemoryStream())
                    {
                        int bufferSize = 64 * 1024;
                        int readBytes = 0;
                        byte[] buffer = new byte[bufferSize];
                        while ((readBytes = reader.Read(buffer, 0, bufferSize)) > 0)
                            ms.Write(buffer, 0, readBytes);
                        return ms.ToArray();
                    }
                }
            }
        }
    }
}