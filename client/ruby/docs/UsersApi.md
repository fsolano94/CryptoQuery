# SwaggerClient::UsersApi

All URIs are relative to *https://localhost*

Method | HTTP request | Description
------------- | ------------- | -------------
[**users_by_id_delete**](UsersApi.md#users_by_id_delete) | **DELETE** /Users/{id} | 
[**users_by_id_get**](UsersApi.md#users_by_id_get) | **GET** /Users/{id} | 
[**users_by_id_update_password_post**](UsersApi.md#users_by_id_update_password_post) | **POST** /Users/{id}/updatePassword | 
[**users_get**](UsersApi.md#users_get) | **GET** /Users | 
[**users_post**](UsersApi.md#users_post) | **POST** /Users | 


# **users_by_id_delete**
> users_by_id_delete(id)



### Example
```ruby
# load the gem
require 'swagger_client'

api_instance = SwaggerClient::UsersApi.new

id = "id_example" # String | 


begin
  api_instance.users_by_id_delete(id)
rescue SwaggerClient::ApiError => e
  puts "Exception when calling UsersApi->users_by_id_delete: #{e}"
end
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | [**String**](.md)|  | 

### Return type

nil (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined



# **users_by_id_get**
> users_by_id_get(id)



### Example
```ruby
# load the gem
require 'swagger_client'

api_instance = SwaggerClient::UsersApi.new

id = "id_example" # String | 


begin
  api_instance.users_by_id_get(id)
rescue SwaggerClient::ApiError => e
  puts "Exception when calling UsersApi->users_by_id_get: #{e}"
end
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | [**String**](.md)|  | 

### Return type

nil (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined



# **users_by_id_update_password_post**
> users_by_id_update_password_post(id, opts)



### Example
```ruby
# load the gem
require 'swagger_client'

api_instance = SwaggerClient::UsersApi.new

id = "id_example" # String | 

opts = { 
  new_password: "new_password_example" # String | 
}

begin
  api_instance.users_by_id_update_password_post(id, opts)
rescue SwaggerClient::ApiError => e
  puts "Exception when calling UsersApi->users_by_id_update_password_post: #{e}"
end
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | [**String**](.md)|  | 
 **new_password** | **String**|  | [optional] 

### Return type

nil (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: Not defined



# **users_get**
> users_get



### Example
```ruby
# load the gem
require 'swagger_client'

api_instance = SwaggerClient::UsersApi.new

begin
  #
  api_instance.users_get
rescue SwaggerClient::ApiError => e
  puts "Exception when calling UsersApi->users_get: #{e}"
end
```

### Parameters
This endpoint does not need any parameter.

### Return type

nil (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined



# **users_post**
> users_post(opts)



### Example
```ruby
# load the gem
require 'swagger_client'

api_instance = SwaggerClient::UsersApi.new

opts = { 
  user_post_dto: SwaggerClient::UserPostDto.new # UserPostDto | 
}

begin
  api_instance.users_post(opts)
rescue SwaggerClient::ApiError => e
  puts "Exception when calling UsersApi->users_post: #{e}"
end
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **user_post_dto** | [**UserPostDto**](UserPostDto.md)|  | [optional] 

### Return type

nil (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: Not defined



