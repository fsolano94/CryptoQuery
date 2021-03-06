=begin
#CryptoQuery API

#API for Senior Project

OpenAPI spec version: v1
Contact: fsolano@nevada.unr.edu
Generated by: https://github.com/swagger-api/swagger-codegen.git
Swagger Codegen version: 2.3.1

=end

require 'spec_helper'
require 'json'
require 'date'

# Unit tests for SwaggerClient::AuthenticatePostDto
# Automatically generated by swagger-codegen (github.com/swagger-api/swagger-codegen)
# Please update as you see appropriate
describe 'AuthenticatePostDto' do
  before do
    # run before each test
    @instance = SwaggerClient::AuthenticatePostDto.new
  end

  after do
    # run after each test
  end

  describe 'test an instance of AuthenticatePostDto' do
    it 'should create an instance of AuthenticatePostDto' do
      expect(@instance).to be_instance_of(SwaggerClient::AuthenticatePostDto)
    end
  end
  describe 'test attribute "token"' do
    it 'should work' do
       # assertion here. ref: https://www.relishapp.com/rspec/rspec-expectations/docs/built-in-matchers
    end
  end

end

