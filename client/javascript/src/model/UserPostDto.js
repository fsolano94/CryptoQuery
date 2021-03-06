/**
 * CryptoQuery API
 * API for Senior Project
 *
 * OpenAPI spec version: v1
 * Contact: fsolano@nevada.unr.edu
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 *
 * Swagger Codegen version: 2.3.1
 *
 * Do not edit the class manually.
 *
 */

(function(root, factory) {
  if (typeof define === 'function' && define.amd) {
    // AMD. Register as an anonymous module.
    define(['ApiClient', 'model/ArticleQueryProfilePostDto'], factory);
  } else if (typeof module === 'object' && module.exports) {
    // CommonJS-like environments that support module.exports, like Node.
    module.exports = factory(require('../ApiClient'), require('./ArticleQueryProfilePostDto'));
  } else {
    // Browser globals (root is window)
    if (!root.CryptoQueryApi) {
      root.CryptoQueryApi = {};
    }
    root.CryptoQueryApi.UserPostDto = factory(root.CryptoQueryApi.ApiClient, root.CryptoQueryApi.ArticleQueryProfilePostDto);
  }
}(this, function(ApiClient, ArticleQueryProfilePostDto) {
  'use strict';




  /**
   * The UserPostDto model module.
   * @module model/UserPostDto
   * @version v1
   */

  /**
   * Constructs a new <code>UserPostDto</code>.
   * @alias module:model/UserPostDto
   * @class
   */
  var exports = function() {
    var _this = this;








  };

  /**
   * Constructs a <code>UserPostDto</code> from a plain JavaScript object, optionally creating a new instance.
   * Copies all relevant properties from <code>data</code> to <code>obj</code> if supplied or a new instance if not.
   * @param {Object} data The plain JavaScript object bearing properties of interest.
   * @param {module:model/UserPostDto} obj Optional instance to populate.
   * @return {module:model/UserPostDto} The populated <code>UserPostDto</code> instance.
   */
  exports.constructFromObject = function(data, obj) {
    if (data) {
      obj = obj || new exports();

      if (data.hasOwnProperty('articleQueryProfile')) {
        obj['articleQueryProfile'] = ArticleQueryProfilePostDto.constructFromObject(data['articleQueryProfile']);
      }
      if (data.hasOwnProperty('createdAt')) {
        obj['createdAt'] = ApiClient.convertToType(data['createdAt'], 'String');
      }
      if (data.hasOwnProperty('updatedAt')) {
        obj['updatedAt'] = ApiClient.convertToType(data['updatedAt'], 'String');
      }
      if (data.hasOwnProperty('email')) {
        obj['email'] = ApiClient.convertToType(data['email'], 'String');
      }
      if (data.hasOwnProperty('userName')) {
        obj['userName'] = ApiClient.convertToType(data['userName'], 'String');
      }
      if (data.hasOwnProperty('hashedPassword')) {
        obj['hashedPassword'] = ApiClient.convertToType(data['hashedPassword'], 'String');
      }
      if (data.hasOwnProperty('salt')) {
        obj['salt'] = ApiClient.convertToType(data['salt'], 'String');
      }
    }
    return obj;
  }

  /**
   * @member {module:model/ArticleQueryProfilePostDto} articleQueryProfile
   */
  exports.prototype['articleQueryProfile'] = undefined;
  /**
   * @member {String} createdAt
   */
  exports.prototype['createdAt'] = undefined;
  /**
   * @member {String} updatedAt
   */
  exports.prototype['updatedAt'] = undefined;
  /**
   * @member {String} email
   */
  exports.prototype['email'] = undefined;
  /**
   * @member {String} userName
   */
  exports.prototype['userName'] = undefined;
  /**
   * @member {String} hashedPassword
   */
  exports.prototype['hashedPassword'] = undefined;
  /**
   * @member {String} salt
   */
  exports.prototype['salt'] = undefined;



  return exports;
}));


