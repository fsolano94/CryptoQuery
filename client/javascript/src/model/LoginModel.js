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
    define(['ApiClient'], factory);
  } else if (typeof module === 'object' && module.exports) {
    // CommonJS-like environments that support module.exports, like Node.
    module.exports = factory(require('../ApiClient'));
  } else {
    // Browser globals (root is window)
    if (!root.CryptoQueryApi) {
      root.CryptoQueryApi = {};
    }
    root.CryptoQueryApi.LoginModel = factory(root.CryptoQueryApi.ApiClient);
  }
}(this, function(ApiClient) {
  'use strict';




  /**
   * The LoginModel model module.
   * @module model/LoginModel
   * @version v1
   */

  /**
   * Constructs a new <code>LoginModel</code>.
   * @alias module:model/LoginModel
   * @class
   */
  var exports = function() {
    var _this = this;



  };

  /**
   * Constructs a <code>LoginModel</code> from a plain JavaScript object, optionally creating a new instance.
   * Copies all relevant properties from <code>data</code> to <code>obj</code> if supplied or a new instance if not.
   * @param {Object} data The plain JavaScript object bearing properties of interest.
   * @param {module:model/LoginModel} obj Optional instance to populate.
   * @return {module:model/LoginModel} The populated <code>LoginModel</code> instance.
   */
  exports.constructFromObject = function(data, obj) {
    if (data) {
      obj = obj || new exports();

      if (data.hasOwnProperty('username')) {
        obj['username'] = ApiClient.convertToType(data['username'], 'String');
      }
      if (data.hasOwnProperty('password')) {
        obj['password'] = ApiClient.convertToType(data['password'], 'String');
      }
    }
    return obj;
  }

  /**
   * @member {String} username
   */
  exports.prototype['username'] = undefined;
  /**
   * @member {String} password
   */
  exports.prototype['password'] = undefined;



  return exports;
}));


