var Game = function() {
    this.frames = [];
}
Game.prototype.toJsonData = function () {
    delete this.score;//delete score field so it wont be send to backend
    return JSON.parse(JSON.stringify(this));
}

var Roll = function(data) {
    this.first = data.first;
    this.second = data.second;
    if (data.third) {
        this.third = data.third;
    }
};
Roll.prototype.toHtml = function () {
    if (this.third) {
        return this.first + ' Second:' + this.second + ' third:' + this.third;
    }
    return 'First: ' + this.first + ' Second:' + this.second ;
}
