using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstresAPI
{
    public class RAM
    {
        public void IncreaseHeap()
        {
            var hHeap = Heap.HeapCreate(Heap.HeapFlags.HEAP_GENERATE_EXCEPTIONS, 0, 0);
            // if the FriendlyName is "heap.vshost.exe" then it's using the VS Hosting Process and not "Heap.Exe"
            //Trace.WriteLine(AppDomain.CurrentDomain.FriendlyName + " heap created");
            uint nSize = 100 * 1024 * 1024;
            ulong nTot = 0;
            try
            {
                for (int i = 0; i < 1000; i++)
                {
                    var ptr = Heap.HeapAlloc(hHeap, 0, nSize);
                    nTot += nSize;
                    //Trace.WriteLine(String.Format("Iter #{0} {1:n0} ", i, nTot));
                }
            }
            catch (Exception ex)
            {
                //Trace.WriteLine("Exception " + ex.Message);
            }
            Heap.HeapDestroy(hHeap);
            //Trace.WriteLine("destroyed");
            //Application.Current.Shutdown();
        }
    }
}
