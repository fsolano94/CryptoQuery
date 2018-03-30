# CryptoQueryApi.UsersApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**usersByIdDelete**](UsersApi.md#usersByIdDelete) | **DELETE** /Users/{id} | 
[**usersByIdGet**](UsersApi.md#usersByIdGet) | **GET** /Users/{id} | 
[**usersByIdUpdatePasswordPost**](UsersApi.md#usersByIdUpdatePasswordPost) | **POST** /Users/{id}/updatePassword | 
[**usersGet**](UsersApi.md#usersGet) | **GET** /Users | 
[**usersPost**](UsersApi.md#usersPost) | **POST** /Users | 


<a name="usersByIdDelete"></a>
# **usersByIdDelete**
> usersByIdDelete(id)



### Example
```javascript
var CryptoQueryApi = require('crypto_query_api');

var apiInstance = new CryptoQueryApi.UsersApi();

var id = "id_example"; // String | 


var callback = function(error, data, response) {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully.');
  }
};
apiInstance.usersByIdDelete(id, callback);
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | [**String**](.md)|  | 

### Return type

null (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

<a name="usersByIdGet"></a>
# **usersByIdGet**
> usersByIdGet(id)



### Example
```javascript
var CryptoQueryApi = require('crypto_query_api');

var apiInstance = new CryptoQueryApi.UsersApi();

var id = "id_example"; // String | 


var callback = function(error, data, response) {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully.');
  }
};
apiInstance.usersByIdGet(id, callback);
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | [**String**](.md)|  | 

### Return type

null (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

<a name="usersByIdUpdatePasswordPost"></a>
# **usersByIdUpdatePasswordPost**
> usersByIdUpdatePasswordPost(id, opts)



### Example
```javascript
var CryptoQueryApi = require('crypto_query_api');

var apiInstance = new CryptoQueryApi.UsersApi();

var id = "id_example"; // String | 

var opts = { 
  'newPassword': "newPassword_example" // String | 
};

var callback = function(error, data, response) {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully.');
  }
};
apiInstance.usersByIdUpdatePasswordPost(id, opts, callback);
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | [**String**](.md)|  | 
 **newPassword** | **String**|  | [optional] 

### Return type

null (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: Not defined

<a name="usersGet"></a>
# **usersGet**
> usersGet()



### Example
```javascript
var CryptoQueryApi = require('crypto_query_api');

var apiInstance = new CryptoQueryApi.UsersApi();

var callback = function(error, data, response) {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully.');
  }
};
apiInstance.usersGet(callback);
```

### Parameters
This endpoint does not need any parameter.

### Return type

null (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

<a name="usersPost"></a>
# **usersPost**
> usersPost(opts)



### Example
```javascript
var CryptoQueryApi = require('crypto_query_api');

var apiInstance = new CryptoQueryApi.UsersApi();

var opts = { 
  'userPostDto': new CryptoQueryApi.UserPostDto() // UserPostDto | 
};

var callback = function(error, data, response) {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully.');
  }
};
apiInstance.usersPost(opts, callback);
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userPostDto** | [**UserPostDto**](UserPostDto.md)|  | [optional] 

### Return type

null (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: Not defined

