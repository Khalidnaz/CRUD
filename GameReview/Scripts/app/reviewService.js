(function () {

    'use strict';

    angular.module(GameReview).factory("ReviewService", ReviewService);
    ReviewService.$inject = ["$http", "$q"];

    function ReviewService($http, $q) {
        var srv = {
            GetReview: _getReview,
            PostReview: _postReview,
            UpdateReview: _updateReview,
            DeleteReview: _deleteReview,
            Scrape: _scrape

        }
        return srv;

        function _getReview() {
            return $http.get("/api/review/reviewList/")
                .then(function (response) {
                    //console.log("reviewservice check");
                    return response.data;
                }).catch(function (err) {
                    return $q.reject(err);
                    console.log("reviewservice error");
                });
        }

        function _postReview(postmodel) {
            console.log("service post js test", postmodel);

            return $http.post("/api/review/", postmodel)
                .then(function (response) {
                    console.log("post check")
                    return response.data;
                }).catch(function (err) {
                    return $q.reject(err);
                    console.log("post error");
                });

        }

        function _updateReview(postmodel) {
            //console.log("service put js test", postmodel);
            return $http.put("/api/review/" + postmodel.Id, postmodel)
                .then(function (response) {
                    return response.data;
                }).catch(function (err) {
                    return $q.reject(err);
                });


        }

        function _deleteReview(itm) {
            return $http.delete("/api/review/" + itm.Id)
                .then(function (response) {
                    return response.data;
                })
                .catch(function (data) {
                    return $q.reject(data);
                });
        }

        function _scrape(model) {
            console.log("hi", model);
        
            return $http.post("/api/review/url/", model)
                .then(function (response) {
                    return response.data;
                    
                })
                .catch(function (data) {
                    return $q.reject(data);
                    
                    
                });
        }
    }
       
})();