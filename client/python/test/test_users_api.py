# coding: utf-8

"""
    CryptoQuery API

    API for Senior Project  # noqa: E501

    OpenAPI spec version: v1
    Contact: fsolano@nevada.unr.edu
    Generated by: https://github.com/swagger-api/swagger-codegen.git
"""


from __future__ import absolute_import

import unittest

import swagger_client
from swagger_client.api.users_api import UsersApi  # noqa: E501
from swagger_client.rest import ApiException


class TestUsersApi(unittest.TestCase):
    """UsersApi unit test stubs"""

    def setUp(self):
        self.api = swagger_client.api.users_api.UsersApi()  # noqa: E501

    def tearDown(self):
        pass

    def test_users_by_id_delete(self):
        """Test case for users_by_id_delete

        """
        pass

    def test_users_by_id_get(self):
        """Test case for users_by_id_get

        """
        pass

    def test_users_by_id_update_password_post(self):
        """Test case for users_by_id_update_password_post

        """
        pass

    def test_users_get(self):
        """Test case for users_get

          # noqa: E501
        """
        pass

    def test_users_post(self):
        """Test case for users_post

        """
        pass


if __name__ == '__main__':
    unittest.main()
