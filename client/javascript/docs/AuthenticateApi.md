# CryptoQueryApi.AuthenticateApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**authenticatePost**](AuthenticateApi.md#authenticatePost) | **POST** /Authenticate | 


<a name="authenticatePost"></a>
# **authenticatePost**
> AuthenticatePostDto authenticatePost(opts)



### Example
```javascript
var CryptoQueryApi = require('crypto_query_api');

var apiInstance = new CryptoQueryApi.AuthenticateApi();

var opts = { 
  'login': new CryptoQueryApi.LoginModel() // LoginModel | 
};

var callback = function(error, data, response) {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully. Returned data: ' + data);
  }
};
apiInstance.authenticatePost(opts, callback);
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **login** | [**LoginModel**](LoginModel.md)|  | [optional] 

### Return type

[**AuthenticatePostDto**](AuthenticatePostDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: application/json

