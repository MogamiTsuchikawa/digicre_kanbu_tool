using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.Graph.Auth;
using System.Security.Cryptography;

namespace OneDriveSlideUploader
{
    class OneDrive
    {
        private GraphServiceClient graphClient;
        public OneDrive()
        {
            
        }
        public async void Setup(IntPtr windowHandle)
        {
            await Graph.CreateGraphClient(windowHandle);


        }
        public async Task<bool> Upload(string oneDriveFolderPath,string targetFilePath)
        {
            string filePath = $"{oneDriveFolderPath}/{System.IO.Path.GetFileName(targetFilePath)}";

            var stream = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(DateTime.Now.ToString()));
            try
            {
                await graphClient
                .Me
                .Drive
                .Root
                .ItemWithPath(filePath)
                .Content
                .Request()
                .PutAsync<DriveItem>(stream);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            

        }
    }
    public static class Graph
    {
        public static GraphServiceClient GraphClient;

        private static string ClientId = "66afa75f-0806-4422-80eb-4569dc88d8a1";
        private static string[] scopes = new string[] { "Files.ReadWrite" };

        public static async Task CreateGraphClient(IntPtr windowHandle)
        {
            IPublicClientApplication PublicClientApp = PublicClientApplicationBuilder.Create(ClientId)
                              .WithAuthority(AzureCloudInstance.AzurePublic, "common")
                              .WithDefaultRedirectUri()
                              .Build();
            TokenCacheHelper.EnableSerialization(PublicClientApp.UserTokenCache);

            IEnumerable<IAccount> accounts = await PublicClientApp.GetAccountsAsync();
            var firstAccount = accounts.FirstOrDefault();

            try
            {
                AuthenticationResult authResult = await PublicClientApp.AcquireTokenSilent(scopes, firstAccount)
                    .ExecuteAsync();
            }
            catch (Exception)
            {
                AuthenticationResult authResult = await PublicClientApp.AcquireTokenInteractive(scopes)
                            .WithAccount(accounts.FirstOrDefault())
                            .WithParentActivityOrWindow(windowHandle)
                            .WithPrompt(Microsoft.Identity.Client.Prompt.SelectAccount)
                            .ExecuteAsync();
            }
            DeviceCodeProvider authProvider = new DeviceCodeProvider(PublicClientApp, scopes);
            GraphClient = new GraphServiceClient(authProvider);
        }
    }
    static class TokenCacheHelper
    {
        public static void EnableSerialization(ITokenCache tokenCache)
        {
            tokenCache.SetBeforeAccess(BeforeAccessNotification);
            tokenCache.SetAfterAccess(AfterAccessNotification);
        }

        public static readonly string CacheFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location + ".msalcache.bin3";

        private static readonly object FileLock = new object();

        private static void BeforeAccessNotification(TokenCacheNotificationArgs args)
        {
            lock (FileLock)
            {
                args.TokenCache.DeserializeMsalV3(System.IO.File.Exists(CacheFilePath)
                        ? ProtectedData.Unprotect(System.IO.File.ReadAllBytes(CacheFilePath),
                                                  null,
                                                  DataProtectionScope.CurrentUser)
                        : null);
            }
        }

        private static void AfterAccessNotification(TokenCacheNotificationArgs args)
        {
            // if the access operation resulted in a cache update
            if (args.HasStateChanged)
            {
                lock (FileLock)
                {
                    // reflect changesgs in the persistent store
                    System.IO.File.WriteAllBytes(CacheFilePath,
                                        ProtectedData.Protect(args.TokenCache.SerializeMsalV3(),
                                                                null,
                                                                DataProtectionScope.CurrentUser)
                                        );
                }
            }
        }
    }
}
