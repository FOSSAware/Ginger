/*
Copyright � 2014-2020 European Support Limited

Licensed under the Apache License, Version 2.0 (the "License")
you may not use this file except in compliance with the License.
You may obtain a copy of the License at 

http://www.apache.org/licenses/LICENSE-2.0 

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS, 
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
See the License for the specific language governing permissions and 
limitations under the License. 
*/

var runningAjaxCount = 0;

var oldSend = XMLHttpRequest.prototype.send;
XMLHttpRequest.prototype.send = function() {
    oldOnReady = this.onreadystatechange;
    this.onreadystatechange = function() {
        oldOnReady.call(this);
        if(this.readyState == XMLHttpRequest.DONE) {
            ajaxStopped();
        }
    }
    ajaxStarted();
    oldSend.apply(this, arguments);
}

function ajaxStarted() {
    runningAjaxCount++;
}

function ajaxStopped() {
    runningAjaxCount--;
}

function isCallingAjax() {
    return runningAjaxCount > 0;
}

function isBrowserBusy() {
    return document.readyState != "complete" && isCallingAjax();
}

function WaitForBrowserIdle()
{

}