﻿using System;
using System.Collections.Generic;
using System.Text;
using Windows.Security.Authentication.Web;
using Windows.UI.Popups;

namespace vk_sharing
{
    public class VkHelper
    {
        public static async void OAuthVk()
        {
            const string vkUri = "https://oauth.vk.com/authorize?client_id=3881112&scope=9999999&" +
                                    "redirect_uri=http://oauth.vk.com/blank.html&display=touch&response_type=token";
            var requestUri = new Uri(vkUri);
            var callbackUri = new Uri("http://oauth.vk.com/blank.html");

            var result = await WebAuthenticationBroker.AuthenticateAsync(
                WebAuthenticationOptions.None, requestUri, callbackUri);

            switch (result.ResponseStatus)
            {
                case WebAuthenticationStatus.ErrorHttp:
                    var dialogError = new MessageDialog("Не удалось открыть страницу сервиса\n" +
                "Попробуйте войти в приложения позже!", "Ошибка");
                    dialogError.ShowAsync();
                    break;
                case WebAuthenticationStatus.Success:
                    var responseString = result.ResponseData;
                    var dialogSuccess = new MessageDialog(responseString);
                    dialogSuccess.ShowAsync();
                    break;
            }
        }
    }
}
