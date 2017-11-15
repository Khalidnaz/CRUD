(function () {
    'use strict';


    angular.module(GameReview).controller("displayReviewController", DisplayReviewController);
    DisplayReviewController.$inject = ["$scope", "ReviewService"];

    function DisplayReviewController($scope, ReviewService) {

        var vm = this;
        vm.$onInit = _init
        vm.model = {};
        vm.postReview = _postReview;
        vm.postmodel = {};
        vm.updateArticle = _updateArticle;
        vm.deleteArticle = _deleteArticle;
        vm.getScrape = _getScrape;
 

        function _init() {

            ReviewService.GetReview()

                .then(function (data) {

                    vm.model = data;
                    console.log(vm.model);

                    
                })

                .catch(function (err) {
                    console.log("err", err);
                });

        }

        function _postReview() {

            ReviewService.PostReview(vm.postmodel)
                .then(function (data) {
                    //vm.postmodel = {};
                    console.log("post check", data);
                    window.location.reload();
                })
                .catch(function (data) {
                    console.log("post failed");
                 
                });



        }

        function _updateArticle(itm) {

            ReviewService.UpdateReview(itm)
                .then(function (data) {
                    console.log("update check", itm);
                    _init();
                })
                .catch(function (data) {
                    console.log("update failed");

                });

        }

        function _deleteArticle(model) {
            ReviewService.DeleteReview(model)
                .then(function (data) {
                    console.log("delete success");
                    _init();
                })
                .catch(function (data) {
                    console.log("delete fail");
                });

        }

        function _getScrape() {
           
            //var urlString = vm.scrapeModel.Url;
           
            //vm.postmodel.Price = "";
            console.log(vm.postmodel);

            ReviewService.Scrape(vm.scrapeModel)
                .then(function (data) {
                
                    console.log("scrape works", data);
                 
                    vm.postmodel.Price = data;

                })
                .catch(function (err) {
                    console.log("scrape fail", err);
                });
        }
       

    }

})();