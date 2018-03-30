# CryptoQueryApi.ArticlesApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**articlesByIdDelete**](ArticlesApi.md#articlesByIdDelete) | **DELETE** /Articles/{id} | 
[**articlesByIdGet**](ArticlesApi.md#articlesByIdGet) | **GET** /Articles/{id} | 
[**articlesGet**](ArticlesApi.md#articlesGet) | **GET** /Articles | 
[**articlesPost**](ArticlesApi.md#articlesPost) | **POST** /Articles | 

<a name="articlesByIdDelete"></a>
# **articlesByIdDelete**
> articlesByIdDelete(id)



### Example
```javascript
var CryptoQueryApi = require('crypto_query_api');

var apiInstance = new CryptoQueryApi.ArticlesApi();

var id = "id_example"; // String | 


var callback = function(error, data, response) {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully.');
  }
};
apiInstance.articlesByIdDelete(id, callback);
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

<a name="articlesByIdGet"></a>
# **articlesByIdGet**
> articlesByIdGet(id)



### Example
```javascript
var CryptoQueryApi = require('crypto_query_api');

var apiInstance = new CryptoQueryApi.ArticlesApi();

var id = "id_example"; // String | 


var callback = function(error, data, response) {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully.');
  }
};
apiInstance.articlesByIdGet(id, callback);
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

<a name="articlesGet"></a>
# **articlesGet**
> articlesGet()



### Example
```javascript
var CryptoQueryApi = require('crypto_query_api');

var apiInstance = new CryptoQueryApi.ArticlesApi();

var callback = function(error, data, response) {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully.');
  }
};
apiInstance.articlesGet(callback);
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

<a name="articlesPost"></a>
# **articlesPost**
> articlesPost(opts)



### Example
```javascript
var CryptoQueryApi = require('crypto_query_api');

var apiInstance = new CryptoQueryApi.ArticlesApi();

var opts = { 
  'articlePostDtoCollection': [new CryptoQueryApi.ArticlePostDto()] // [ArticlePostDto] | 
};

var callback = function(error, data, response) {
  if (error) {
    console.error(error);
  } else {
    console.log('API called successfully.');
  }
};
apiInstance.articlesPost(opts, callback);
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **articlePostDtoCollection** | [**[ArticlePostDto]**](ArticlePostDto.md)|  | [optional] 

### Return type

null (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/_*+json
 - **Accept**: Not defined

