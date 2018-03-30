# SwaggerClient::AuthenticateApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**authenticate_post**](AuthenticateApi.md#authenticate_post) | **POST** /Authenticate | 


# **authenticate_post**
> AuthenticatePostDto authenticate_post(opts)



### Example
```ruby
# load the gem
require 'swagger_client'

api_instance = SwaggerClient::AuthenticateApi.new

opts = { 
  login: SwaggerClient::LoginModel.new # LoginModel | 
}

begin
  result = api_instance.authenticate_post(opts)
  p result
rescue SwaggerClient::ApiError => e
  puts "Exception when calling AuthenticateApi->authenticate_post: #{e}"
end
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



