// <copyright file="SigninSampleScript.cs" company="Google Inc.">
// Copyright (C) 2017 Google Inc. All Rights Reserved.
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations

namespace SignInSample
{
    using Google;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UnityEngine;
    using UnityEngine.UI;

    public class SigninSampleScript : MonoBehaviour
    {
        public Text statusText;

        public string webClientId = "<your client id here>";

        private GoogleSignInConfiguration configuration;


        void Awake()
        {
            configuration = new GoogleSignInConfiguration
            {
                WebClientId = webClientId,
                RequestIdToken = true
            };
        }

        public async void OnSignIn()
        {
            GoogleSignIn.Configuration = configuration;
            GoogleSignIn.Configuration.UseGameSignIn = false;
            GoogleSignIn.Configuration.RequestIdToken = true;
            GoogleSignIn.Configuration.RequestEmail = true;


            var task = await GoogleSignIn.DefaultInstance.SignIn();
            if (task != null)
            {
                AuthManager.instance.GoogleSignIn(task.IdToken);
            }
        }

        public void OnSignOut()
        {

            GoogleSignIn.DefaultInstance.SignOut();
        }

        public void OnDisconnect()
        {

            GoogleSignIn.DefaultInstance.Disconnect();
        }

        internal void OnAuthenticationFinished(Task<GoogleSignInUser> task)
        {
            if (task.IsFaulted)
            {
                using (IEnumerator<System.Exception> enumerator =
                        task.Exception.InnerExceptions.GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        GoogleSignIn.SignInException error =
                                (GoogleSignIn.SignInException)enumerator.Current;

                    }
                    else
                    {

                    }
                }
            }
            else if (task.IsCanceled)
            {
            }
            else
            {
                AuthManager.instance.GoogleSignIn(task.Result.IdToken);
            }
        }

        public void OnSignInSilently()
        {
            GoogleSignIn.Configuration = configuration;
            GoogleSignIn.Configuration.UseGameSignIn = false;
            GoogleSignIn.Configuration.RequestIdToken = true;


            GoogleSignIn.DefaultInstance.SignInSilently()
                  .ContinueWith(OnAuthenticationFinished);
        }


        public void OnGamesSignIn()
        {
            GoogleSignIn.Configuration = configuration;
            GoogleSignIn.Configuration.UseGameSignIn = true;
            GoogleSignIn.Configuration.RequestIdToken = false;



            GoogleSignIn.DefaultInstance.SignIn().ContinueWith(
              OnAuthenticationFinished);
        }

        private List<string> messages = new List<string>();

    }
}
