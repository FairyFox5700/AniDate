"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.reducer = exports.actionCreators = void 0;
// ----------------
// ACTION CREATORS - These are functions exposed to UI components that will trigger a state transition.
// They don't directly mutate state, but they can have external side-effects (such as loading data).
exports.actionCreators = {
    requestUser: function () { return ({ type: 'REQUEST_USER_FORECAST' }); }
};
// ----------------
// REDUCER - For a given state and action, returns the new state. To support time travel, this must not mutate the old state.
var unloadedState = {
    currentUser: { name: "Андрій" }
};
var reducer = function (state, incomingAction) {
    if (state === undefined) {
        return unloadedState;
    }
    return state;
};
exports.reducer = reducer;
//# sourceMappingURL=User.js.map