# coding: utf-8

"""
    CryptoQuery API

    API for Senior Project  # noqa: E501

    OpenAPI spec version: v1
    Contact: fsolano@nevada.unr.edu
    Generated by: https://github.com/swagger-api/swagger-codegen.git
"""


import pprint
import re  # noqa: F401

import six

from swagger_client.models.article_query_profile_post_dto import ArticleQueryProfilePostDto  # noqa: F401,E501


class UserPostDto(object):
    """NOTE: This class is auto generated by the swagger code generator program.

    Do not edit the class manually.
    """

    """
    Attributes:
      swagger_types (dict): The key is attribute name
                            and the value is attribute type.
      attribute_map (dict): The key is attribute name
                            and the value is json key in definition.
    """
    swagger_types = {
        'article_query_profile': 'ArticleQueryProfilePostDto',
        'created_at': 'str',
        'updated_at': 'str',
        'email': 'str',
        'user_name': 'str',
        'hashed_password': 'str',
        'salt': 'str'
    }

    attribute_map = {
        'article_query_profile': 'articleQueryProfile',
        'created_at': 'createdAt',
        'updated_at': 'updatedAt',
        'email': 'email',
        'user_name': 'userName',
        'hashed_password': 'hashedPassword',
        'salt': 'salt'
    }

    def __init__(self, article_query_profile=None, created_at=None, updated_at=None, email=None, user_name=None, hashed_password=None, salt=None):  # noqa: E501
        """UserPostDto - a model defined in Swagger"""  # noqa: E501

        self._article_query_profile = None
        self._created_at = None
        self._updated_at = None
        self._email = None
        self._user_name = None
        self._hashed_password = None
        self._salt = None
        self.discriminator = None

        if article_query_profile is not None:
            self.article_query_profile = article_query_profile
        if created_at is not None:
            self.created_at = created_at
        if updated_at is not None:
            self.updated_at = updated_at
        if email is not None:
            self.email = email
        if user_name is not None:
            self.user_name = user_name
        if hashed_password is not None:
            self.hashed_password = hashed_password
        if salt is not None:
            self.salt = salt

    @property
    def article_query_profile(self):
        """Gets the article_query_profile of this UserPostDto.  # noqa: E501


        :return: The article_query_profile of this UserPostDto.  # noqa: E501
        :rtype: ArticleQueryProfilePostDto
        """
        return self._article_query_profile

    @article_query_profile.setter
    def article_query_profile(self, article_query_profile):
        """Sets the article_query_profile of this UserPostDto.


        :param article_query_profile: The article_query_profile of this UserPostDto.  # noqa: E501
        :type: ArticleQueryProfilePostDto
        """

        self._article_query_profile = article_query_profile

    @property
    def created_at(self):
        """Gets the created_at of this UserPostDto.  # noqa: E501


        :return: The created_at of this UserPostDto.  # noqa: E501
        :rtype: str
        """
        return self._created_at

    @created_at.setter
    def created_at(self, created_at):
        """Sets the created_at of this UserPostDto.


        :param created_at: The created_at of this UserPostDto.  # noqa: E501
        :type: str
        """

        self._created_at = created_at

    @property
    def updated_at(self):
        """Gets the updated_at of this UserPostDto.  # noqa: E501


        :return: The updated_at of this UserPostDto.  # noqa: E501
        :rtype: str
        """
        return self._updated_at

    @updated_at.setter
    def updated_at(self, updated_at):
        """Sets the updated_at of this UserPostDto.


        :param updated_at: The updated_at of this UserPostDto.  # noqa: E501
        :type: str
        """

        self._updated_at = updated_at

    @property
    def email(self):
        """Gets the email of this UserPostDto.  # noqa: E501


        :return: The email of this UserPostDto.  # noqa: E501
        :rtype: str
        """
        return self._email

    @email.setter
    def email(self, email):
        """Sets the email of this UserPostDto.


        :param email: The email of this UserPostDto.  # noqa: E501
        :type: str
        """

        self._email = email

    @property
    def user_name(self):
        """Gets the user_name of this UserPostDto.  # noqa: E501


        :return: The user_name of this UserPostDto.  # noqa: E501
        :rtype: str
        """
        return self._user_name

    @user_name.setter
    def user_name(self, user_name):
        """Sets the user_name of this UserPostDto.


        :param user_name: The user_name of this UserPostDto.  # noqa: E501
        :type: str
        """

        self._user_name = user_name

    @property
    def hashed_password(self):
        """Gets the hashed_password of this UserPostDto.  # noqa: E501


        :return: The hashed_password of this UserPostDto.  # noqa: E501
        :rtype: str
        """
        return self._hashed_password

    @hashed_password.setter
    def hashed_password(self, hashed_password):
        """Sets the hashed_password of this UserPostDto.


        :param hashed_password: The hashed_password of this UserPostDto.  # noqa: E501
        :type: str
        """

        self._hashed_password = hashed_password

    @property
    def salt(self):
        """Gets the salt of this UserPostDto.  # noqa: E501


        :return: The salt of this UserPostDto.  # noqa: E501
        :rtype: str
        """
        return self._salt

    @salt.setter
    def salt(self, salt):
        """Sets the salt of this UserPostDto.


        :param salt: The salt of this UserPostDto.  # noqa: E501
        :type: str
        """

        self._salt = salt

    def to_dict(self):
        """Returns the model properties as a dict"""
        result = {}

        for attr, _ in six.iteritems(self.swagger_types):
            value = getattr(self, attr)
            if isinstance(value, list):
                result[attr] = list(map(
                    lambda x: x.to_dict() if hasattr(x, "to_dict") else x,
                    value
                ))
            elif hasattr(value, "to_dict"):
                result[attr] = value.to_dict()
            elif isinstance(value, dict):
                result[attr] = dict(map(
                    lambda item: (item[0], item[1].to_dict())
                    if hasattr(item[1], "to_dict") else item,
                    value.items()
                ))
            else:
                result[attr] = value

        return result

    def to_str(self):
        """Returns the string representation of the model"""
        return pprint.pformat(self.to_dict())

    def __repr__(self):
        """For `print` and `pprint`"""
        return self.to_str()

    def __eq__(self, other):
        """Returns true if both objects are equal"""
        if not isinstance(other, UserPostDto):
            return False

        return self.__dict__ == other.__dict__

    def __ne__(self, other):
        """Returns true if both objects are not equal"""
        return not self == other