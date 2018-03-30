# SwaggerClient::ArticlesApi

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
```ruby
# load the gem
require 'swagger_client'

api_instance = SwaggerClient::ArticlesApi.new

id = "id_example" # String | 


begin
  api_instance.articles_by_id_delete(id)
rescue SwaggerClient::ApiError => e
  puts "Exception when calling ArticlesApi->articles_by_id_delete: #{e}"
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



# **articles_by_id_get**
> articles_by_id_get(id)



### Example
```ruby
# load the gem
require 'swagger_client'

api_instance = SwaggerClient::ArticlesApi.new

id = "id_example" # String | 


begin
  api_instance.articles_by_id_get(id)
rescue SwaggerClient::ApiError => e
  puts "Exception when calling ArticlesApi->articles_by_id_get: #{e}"
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



# **articles_get**
> articles_get



### Example
```ruby
# load the gem
require 'swagger_client'

api_instance = SwaggerClient::ArticlesApi.new

begin
  #
  api_instance.articles_get
rescue SwaggerClient::ApiError => e
  puts "Exception when calling ArticlesApi->articles_get: #{e}"
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



# **articles_post**
> articles_post(opts)



### Example
```ruby
# load the gem
require 'swagger_client'

api_instance = SwaggerClient::ArticlesApi.new

opts = { 
  article_post_dto_collection: [SwaggerClient::ArticlePostDto.new] # Array<ArticlePostDto> | 
}

begin
  api_instance.articles_post(opts)
rescue SwaggerClient::ApiError => e
  puts "Exception when calling ArticlesApi->articles_post: #{e}"
end
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **article_post_dto_collection** | [**Array&lt;ArticlePostDto&gt;**](ArticlePostDto.md)|  | [optional] 

### Return type

nil (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json-patch+json, application/json, text/json, application/*+json
 - **Accept**: Not defined



