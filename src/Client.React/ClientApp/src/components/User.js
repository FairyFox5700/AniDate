"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var react_redux_1 = require("react-redux");
var UserStore = require("../store/User");
var User = /** @class */ (function (_super) {
    __extends(User, _super);
    function User() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    User.prototype.render = function () {
        return (React.createElement(React.Fragment, null,
            React.createElement("h1", null, "User"),
            React.createElement("p", { "aria-live": "polite" },
                "Name: ",
                React.createElement("strong", null, this.props.currentUser.name))));
    };
    return User;
}(React.PureComponent));
;
exports.default = react_redux_1.connect(function (state) { return state.user; }, UserStore.actionCreators)(User);
//# sourceMappingURL=User.js.map