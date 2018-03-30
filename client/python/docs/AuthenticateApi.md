# swagger_client.AuthenticateApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**authenticate_post**](AuthenticateApi.md#authenticate_post) | **POST** /Authenticate | 


# **authenticate_post**
> AuthenticatePostDto authenticate_post(login=login)



### Example
```python
from __future__ import print_function
import time
import swagger_client
from swagger_client.rest import ApiException
from pprint import pprint

# create an instance of the API class
api_instance = swagger_client.AuthenticateApi()
login = swagger_client.LoginModel() # LoginModel |  (optional)

try:
    api_response = api_instance.authenticate_post(login=login)
    pprint(api_response)
except ApiException as e:
    print("Exception when calling AuthenticateApi->authenticate_post: %s\n" % e)
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

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

