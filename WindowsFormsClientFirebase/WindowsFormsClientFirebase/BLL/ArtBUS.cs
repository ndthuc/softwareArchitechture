using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Firebase.Database;
using Firebase.Database.Query;
using System.Windows.Forms;

using WindowsFormsClientFirebase.DTO;

namespace WindowsFormsClientFirebase.BLL
{
    class ArtBUS
    {
        private const String FIREBASE_APP = "https://tin415de01art.firebaseio.com/";
        private FirebaseClient firebase = new FirebaseClient(FIREBASE_APP);

        public void ListenFirebase(DataGridView dataGridView1)
        {
            firebase.Child("artItems").AsObservable<ArtItem>().Subscribe((item) => { UpdateDataGridView(dataGridView1); });
        }

        private async void UpdateDataGridView(DataGridView dataGridView)
        {
            List<ArtItem> artItems = await GetAll();
            dataGridView.BeginInvoke(new MethodInvoker(delegate { dataGridView.DataSource = artItems; })); // set asynchronous datasource
        }

        private async Task<List<ArtItem>> GetAll()
        {
            List<ArtItem> artItems = new List<ArtItem>();
            var fbArtItems = await firebase.Child("artItems").OnceAsync<ArtItem>();
            foreach (var item in fbArtItems)
                artItems.Add(item.Object);
            return artItems;
        }

        public async Task<ArtItem> GetDetails(int code)
        {
            var fbArtItems = await firebase.Child("artItems").OnceAsync<ArtItem>();
            foreach (var item in fbArtItems)
                if (item.Object.Code == code)
                    return item.Object;
            return null;
        }

        private async Task<String> GetKeyByCode(int code)
        {
            var fbArtItems = await firebase.Child("artItems").OnceAsync<ArtItem>();
            foreach (var item in fbArtItems)
                if (item.Object.Code == code)
                    return item.Key;
            return null;
        }

        public async Task<List<ArtItem>> Search(String keyword)
        {
            List<ArtItem> artItems = new List<ArtItem>();
            var fbArtItems = await firebase.Child("artItems").OnceAsync<ArtItem>();
            foreach (var item in fbArtItems)
                if (item.Object.Name.ToLower().Contains(keyword.ToLower()))
                    artItems.Add(item.Object);
            return artItems;
        }

        public async Task<bool> AddNew(ArtItem newItem)
        {
            try
            {
                //await firebase.Child("books").PostAsync(newBook); // auto-generated key
                await firebase.Child("artItems").Child("art" + newItem.Code).PutAsync(newItem); // custom key
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> Update(ArtItem updatedItem)
        {
            try
            {
                String key = await GetKeyByCode(updatedItem.Code);
                if (String.IsNullOrEmpty(key)) return false;
                await firebase.Child("artItems").Child(key).PutAsync(updatedItem);
                return true;
            }
            catch { return false; }
        }

        public async Task<bool> Delete(int code)
        {
            try
            {
                String key = await GetKeyByCode(code);
                if (String.IsNullOrEmpty(key)) return false;
                await firebase.Child("artItems").Child(key).DeleteAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
