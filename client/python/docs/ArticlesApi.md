# swagger_client.ArticlesApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**articles_by_id_delete**](ArticlesApi.md#articles_by_id_delete) | **DELETE** /Articles/{id} | 
[**articles_by_id_get**](ArticlesApi.md#articles_by_id_get) | **GET** /Articles/{id} | 
[**articles_get**](ArticlesApi.md#articles_get) | **GET** /Articles | 
[**articles_post**](ArticlesApi.md#articles_post) | **POST** /Articles | 


# **articles_by_id_delete**
> articles_by_id_delete(id)



### Example
```python
from __future__ import print_function
import time
import swagger_client
from swagger_client.rest import ApiException
from pprint import pprint

# create an instance of the API class
api_instance = swagger_client.ArticlesApi()
id = 'id_example' # str | 

try:
    api_instance.articles_by_id_delete(id)
except ApiException as e:
    print("Exception when calling ArticlesApi->articles_by_id_delete: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | [**str**](.md)|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **articles_by_id_get**
> articles_by_id_get(id)



### Example
```python
from __future__ import print_function
import time
import swagger_client
from swagger_client.rest import ApiException
from pprint import pprint

# create an instance of the API class
api_instance = swagger_client.ArticlesApi()
id = 'id_example' # str | 

try:
    api_instance.articles_by_id_get(id)
except ApiException as e:
    print("Exception when calling ArticlesApi->articles_by_id_get: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | [**str**](.md)|  | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **articles_get**
> articles_get()



### Example
```python
from __future__ import print_function
import time
import swagger_client
from swagger_client.rest import ApiException
from pprint import pprint

# create an instance of the API class
api_instance = swagger_client.ArticlesApi()

try:
    # 
    api_instance.articles_get()
except ApiException as e:
    print("Exception when calling ArticlesApi->articles_get: %s\n" % e)
```

### Parameters
This endpoint does not need any parameter.

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **articles_post**
> articles_post(article_post_dto_collection=article_post_dto_collection)



### Example
```python
from __future__ import print_function
import time
import swagger_client
from swagger_client.rest import ApiException
from pprint import pprint

# create an instance of the API class
api_instance = swagger_client.ArticlesApi()
article_post_dto_collection = [swagger_client.ArticlePostDto()] # list[ArticlePostDto] |  (optional)

try:
    api_instance.articles_post(article_post_dto_collection=article_post_dto_collection)
except ApiException as e:
    print("Exception when calling ArticlesApi->articles_post: %s\n" % e)
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **article_post_dto_collection** | [**list[ArticlePostDto]**](ArticlePostDto.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

