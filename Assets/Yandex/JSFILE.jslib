mergeInto(LibraryManager.library, {

  Hello: function () {
    console.log("Hello, world");
    window.alert("Hello, world");
    },

  GetPlayerData: function () {
    MyGameInstance.SendMessage("YandexIntegration", "SetName", player.getName());
    console.log(player.getName());
  },

  SaveExtern: function (date) {
    var dateString = UTF8ToString(date);
    var myobj = JSON.parse(dateString);
    player.setData(myobj);
  },

  LoadExtern: function () {
    player.getData().then (_data => {
      const myJSON = JSON.stringify(_data);
      MyGameInstance.SendMessage('YandexIntegration', 'SetPlayerInfo', myJSON);
    });
  },
  SendToLeaderBoard : function (value){
        ysdk.getLeaderboards()
      .then(lb => {
        lb.setLeaderboardScore('Survivability', value);
      });
  },

  RateGame : function ()
  {
    ysdk.feedback.canReview()
            .then(({ value, reason }) => {
                if (value) {
                    ysdk.feedback.requestReview()
                        .then(({ feedbackSent }) => {
                            console.log(feedbackSent);
                        })
                } else {
                    console.log(reason)
                }
            })
    },

});