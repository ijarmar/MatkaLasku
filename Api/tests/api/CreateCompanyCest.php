<?php 

class CreateCompanyCest
{
    // tests
    public function createCompanyViaAPI(\ApiTester $I)
    {
        $I->haveHttpHeader('Content-Type', 'application/json');
        $I->sendPost('/Companies', [
            'name' => 'Sovelluskontti'
        ]);
        $I->seeResponseCodeIs(\Codeception\Util\HttpCode::CREATED);
        $I->seeResponseIsJson();
        $I->seeResponseContains('"name":"Sovelluskontti"');
    }
}
